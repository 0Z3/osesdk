#ifndef OSEBASE_H
#define OSEBASE_H

#include "ose.h"
#include "ose_util.h"
#include "ose_stackops.h"
#include "ose_vm.h"

#define OSE_WRAPPER_DECL(name)                      \
    extern "C"                                      \
    void ose_##name ##_wrapper(ose_bundle osevm);

#define OSE_WRAPPER_DEFN(name)                            \
    extern "C"                                              \
    void ose_##name ##_wrapper(ose_bundle osevm)            \
    {                                                       \
        std::cout << __func__ << ":" << __LINE__ << "\n";   \
        std::cout << "*****\n";                             \
        THISCLASS *base = (THISCLASS *)getself(osevm);          \
        base->ose_##name(osevm);                            \
        std::cout << "*****\n";                             \
    }

#define OSE_WRAPPER_TAB__(cls) cls ## _wrappertab
#define OSE_WRAPPER_TAB_(cls) OSE_WRAPPER_TAB__(cls)
#define OSE_WRAPPER_TAB OSE_WRAPPER_TAB_(THISCLASS)

#define OSE_WRAPPER_TAB_TYPE__(cls) struct _##cls ## _wrappertab
#define OSE_WRAPPER_TAB_TYPE_(cls) OSE_WRAPPER_TAB_TYPE__(cls)
#define OSE_WRAPPER_TAB_TYPE OSE_WRAPPER_TAB_TYPE_(THISCLASS)

#define OSE_WRAPPER_TAB_DEFN__(cls, ...)     \
    struct _##cls ##_wrappertab             \
    {                                           \
        const char * const name;                \
        void *fn;                               \
    } cls ##_wrappertab [] =               \
    {                                           \
        __VA_ARGS__                             \
    };

#define OSE_WRAPPER_TAB_DEFN_(cls, ...)                   \
    OSE_WRAPPER_TAB_DEFN__(cls, __VA_ARGS__)
#define OSE_WRAPPER_TAB_DEFN(...) OSE_WRAPPER_TAB_DEFN_(THISCLASS, __VA_ARGS__)


#define OSE_WRAPPER_BIND(name)                      \
    { "/" #name , (void *)ose_ ##name ##_wrapper }

#define OSE_WRAPPER_TAB_LENGTH_(cls)             \
    sizeof(OSE_WRAPPER_TAB)                \
    / sizeof(OSE_WRAPPER_TAB_TYPE)
#define OSE_WRAPPER_TAB_LENGTH OSE_WRAPPER_TAB_LENGTH_(THISCLASS)

extern "C" {

/* for debugging */
#ifdef OSE_DEBUG
// __attribute__((used))
static void pbndl(ose_bundle bundle, const char * const str)
{
    /* char buf[65536]; */
    /* memset(buf, 0, 65536); */
    int32_t n = ose_pprintBundle(bundle, NULL, 0);
    char buf[n + 1];
    memset(buf, 0, n + 1);
    ose_pprintBundle(bundle, buf, n + 1);
    fprintf(stderr, "\n\r%s>>>>>\n\r%s\n\r%s<<<<<\n\r",
            str, buf, str);
}
// __attribute__((used))
static void pbytes(ose_bundle bundle, int32_t start, int32_t end)
{
    char *b = ose_getBundlePtr(bundle);
    for(int32_t i = start; i < end; i++)
    {
        fprintf(stderr, "%d: %c %d\n\r", i,
                (unsigned char)b[i],
                (unsigned char)b[i]);
    }
}
#endif

void *getself(ose_bundle osevm)
{
    return (void *)*((intptr_t *)(ose_getBundlePtr(osevm)
                                  + OSEVM_CACHE_OFFSET_8));
}

void ose_base_lookup(ose_bundle osevm)
{
    ose_bundle vm_s = OSEVM_STACK(osevm);
    ose_bundle vm_e = OSEVM_ENV(osevm);
    ose_bundle vm_x = ose_enter(osevm, "/_x");
    ose_bundle bndlenv = vm_e;
    int explicitbndl = 0;

    if(ose_peekType(vm_s) != OSETT_MESSAGE
       || !ose_isStringType(ose_peekMessageArgType(vm_s)))
    {
        /* this is probably an error */
        return;
    }
    const char * const address = ose_peekString(vm_s);
    if(address[3] == '/')
    {
        const char buf[4] = {
            address[0],
            address[1],
            address[2],
            0
        };
        int32_t o = ose_getContextMessageOffset(osevm, buf);
        if(o >= 0)
        {
            bndlenv = ose_enterBundleAtOffset(osevm, o);
            explicitbndl = 1;
        }
    }

    if(explicitbndl)
    {
        int32_t mo = ose_getFirstOffsetForMatch(bndlenv,
                                                address + 3);
        if(mo >= OSE_BUNDLE_HEADER_LEN)
        {
            ose_drop(vm_s);
            ose_copyElemAtOffset(mo, bndlenv, vm_s);
            return;
        }
    }
    else
    {
        int32_t mo = ose_getFirstOffsetForMatch(vm_e, address);
        if(mo >= OSE_BUNDLE_HEADER_LEN)
        {
            ose_drop(vm_s);
            ose_copyElemAtOffset(mo, vm_e, vm_s);
            return;
        }
        /* if it wasn't present in env, lookup in _x */
        mo = ose_getFirstOffsetForMatch(vm_x, address);
        if(mo >= OSE_BUNDLE_HEADER_LEN)
        {
            ose_drop(vm_s);
            ose_copyElemAtOffset(mo, vm_x, vm_s);
            return;
        }
    }
}

void ose_bindAlignedPtr(ose_bundle B,
                        const char * const addr,
                        int32_t addrlen,
                        void *ptr)
{
    ose_pushString(B, addr);
    ose_moveStringToAddress(B);
    ose_pushAlignedPtr(B, ptr);
    ose_push(B);
}
} // extern "C"

class OSEBase
{
public:
    char *bytes;
    ose_bundle bundle, osevm,
        vm_i, vm_s, vm_e, vm_c, vm_d, vm_x;
    
    virtual ~OSEBase(void)
    {
        if(bytes)
        {
            free(bytes);
        }
    };
    virtual void init(void)
    {
        bytes = (char *)calloc(8388608, 1);
        bundle = ose_newBundleFromCBytes(8388608, bytes);
        osevm = osevm_init(bundle);
        ose_pushContextMessage(osevm, 1048576, "/_x");
        vm_i = ose_enter(osevm, "/_i");
        vm_s = ose_enter(osevm, "/_s");
        vm_c = ose_enter(osevm, "/_c");
        vm_e = ose_enter(osevm, "/_e");
        vm_x = ose_enter(osevm, "/_x");

        ose_bindAlignedPtr(vm_x, "/self", 5, (void *)this);
        *((intptr_t *)(ose_getBundlePtr(osevm)
                       + OSEVM_CACHE_OFFSET_8))
            = (intptr_t)this;
    }

    void *getself()
    {
        return (void *)this;
    }

#pragma SWIG nowarn=473    
    // Warning 473 from SWIG tells us not to return a pointer
    // from a director method, because it may become
    // garbage collected, but here, we're returning a function
    // pointer, which will (I HOPE) always be valid

	virtual void *getfnptr(const char * const fname)
    {
        return NULL;
    }

    unsigned char *copyElem(unsigned char *dest,
                            ose_bundle reg,
                            int32_t offset,
                            int32_t size)
    {
        const char * const b = ose_getBundlePtr(reg);
        return (unsigned char *)memcpy(dest, b + offset, size + 4);
    }

    void run(void)
    {
        osevm_run(osevm);
    }

    void input(int32_t len, const unsigned char * const packet)
    {
        ose_pushBlob(vm_i, len, (char *)packet);
        ose_blobToElem(vm_i);
        if(ose_peekType(vm_i) == OSETT_BUNDLE)
        {
            ose_popAllDrop(vm_i);
        }
    }

};

#endif
