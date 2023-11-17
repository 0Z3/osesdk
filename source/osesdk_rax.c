#include "osesdk_rax.h"
#include "ose_util.h"
#include "ose_context.h"
#include "ose_stackops.h"
#include "ose_assert.h"
#include "rax/rax.h"

#include <string.h> // for strlen
#include <stdlib.h> // for malloc, etc. DELETE ME

/* #define PROFILE */
#ifdef PROFILE
#include <mach/mach_time.h>
mach_timebase_info_data_t timebase;
int timer_initialized;
#define TIMER_INIT                                          \
    if(!timer_initialized)                                  \
    {                                                       \
        if(mach_timebase_info(&timebase) != KERN_SUCCESS)   \
        {                                                   \
            printf("couldn't get timebase\n");              \
        }                                                   \
        timer_initialized = 1;                              \
    }
#define TIMER_START(t) uint64_t t = mach_absolute_time()
#define TIMER_END(t) uint64_t t = mach_absolute_time()
#define TIMER_DIFF(t1, t2, t3)                  \
    double t3 = -1;                             \
    if(timer_initialized)                       \
    {                                           \
    t3 = (((t2) - (t1))                         \
          * (timebase.numer / timebase.denom))  \
        / 1000000.;                             \
    }
#define TIMER_PRINT(t1, t2, t3, ...)            \
    TIMER_DIFF(t1, t2, t3);                     \
    if(timer_initialized)                       \
    {                                           \
        printf(__VA_ARGS__);                    \
    }
#else
#define TIMER_START(t) do{}while(0)
#define TIMER_END(t) do{}while(0)
#define TIMER_DIFF(t1, t2, t3) do{}while(0)
#define TIMER_PRINT(t1, t2, t3, ...) do{}while(0)
#define TIMER_INIT
#endif

struct osesdk_rax_obj
{
    char *mem;
    int32_t memsize;
    int32_t memloc;
    rax *raxobj;
};

void osesdk_rax_init(ose_bundle bundle,
                     int32_t raxmemsize, char *raxmem)
{
    TIMER_INIT;
    struct osesdk_rax_obj *o = (struct osesdk_rax_obj *)raxmem;
    o->mem = raxmem + sizeof(struct osesdk_rax_obj);
    o->memsize = raxmemsize - sizeof(struct osesdk_rax_obj);
    o->memloc = 0;
    o->raxobj = NULL;
    ose_context_set_cachefns(bundle,
                             /* osesdk_rax_onchange, */
                             osesdk_rax_getFirstOffsetForMatch,
                             (void *)o);
}

int32_t osesdk_rax_getFirstOffsetForMatch(ose_bundle bundle,
                                          const char * const address,
                                          void **userdata)
{
    /* static int count; */
    /* ++count; */
    /* printf("%s: count = %d\n", __func__, count); */
    ose_assert(ose_isBundle(bundle));
    ose_assert(address);
    {
        struct osesdk_rax_obj *o = (struct osesdk_rax_obj *)(*userdata);
        /* rax *raxobj = *((rax **)userdata); */
        void *p;
        if(!(o->raxobj) || ose_context_get_changed(bundle))
        {
            osesdk_rax_buildTree(bundle, userdata);
            /* raxobj = *((rax **)userdata); */
            ose_context_reset_changed(bundle);
        }
        /* TIMER_START(t1); */
        p = raxFind(o->raxobj,
                    /* no harm here--rax doesn't alter this */
                    (unsigned char *)address,
                    strlen(address),
                    (void *)o);
        /* TIMER_END(t2); */
        /* TIMER_PRINT(t1, t2, t3, */
        /*             "%s: found %s in %f ms\n", __func__, address, t3); */
        if(p == raxNotFound)
        {
            return 0;
        }
        else
        {
            return (int32_t)((uintptr_t)p);
        }
    }
}

void osesdk_rax_buildTree(ose_bundle bundle,
                          void **userdata)
{
    /* static int count; */
    /* ++count; */
    /* printf("%s: count = %d\n", __func__, count); */
    ose_assert(ose_isBundle(bundle));
    TIMER_START(t1);
    {
        struct osesdk_rax_obj *o = (struct osesdk_rax_obj *)(*userdata);
        /* rax *raxobj = *((rax **)userdata); */
        char *b = ose_getBundlePtr(bundle);
        int32_t s = ose_readSize(bundle);
        intptr_t oo = OSE_BUNDLE_HEADER_LEN;
        int32_t n = 0;
    
        if(o->raxobj)
        {
            /* raxFree(o->raxobj, (void *)o); */
            o->memloc = 0;
        }
        o->raxobj = raxNew((void *)o);

        while(oo < s)
        {
            void *old = NULL;
            raxInsert(o->raxobj,
                      (unsigned char *)(b + oo + 4),
                      strlen(b + oo + 4),
                      (void *)oo,
                      &old,
                      (void *)o);
            oo += ose_readInt32(bundle, oo) + 4;
            ++n;
        }
        /* *userdata = (void *)raxobj; */
        TIMER_END(t2);
        TIMER_PRINT(t1, t2, t3,
                    "%s: cached %d keys in %f ms, allocated %d bytes\n", __func__, n, t3, o->memloc);
    }
}

void *osesdk_rax_malloc(size_t size, void *context)
{
    struct osesdk_rax_obj *o = (struct osesdk_rax_obj *)context;
    char *ptr = o->mem + o->memloc;
    *((int32_t *)ptr) = (int32_t)size;
    o->memloc += size + 4;
    return ptr + 4;
    /* return malloc(size); */
}

void *osesdk_rax_realloc(void *ptr, size_t size, void *context)
{
    char *newptr = osesdk_rax_malloc(size, context);
    memcpy(newptr, ptr, *((int32_t *)(ptr - 4)));
    return newptr;
    /* return realloc(ptr, size); */
}

void osesdk_rax_free(void *ptr, void *context)
{
    /* free(ptr); */
}
