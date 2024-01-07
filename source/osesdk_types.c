#include <stdio.h> // for snprintf
#include <string.h> // for strcmp

#include "osesdk_types.h"
#include "libose/ose_context.h"
#include "libose/ose_util.h"
#include "libose/ose_stackops.h"
#include "libose/ose_vm.h"
#include "libose/ose_assert.h"

/* static ose_bundle getTypeBundle(ose_constbundle B) */
/* { */
/*     ose_bundle bb = B; */
/*     while(1) */
/*     { */
/*         int32_t o = ose_getContextMessageOffset(ose_exit(bb), "/_t"); */
/*         if(o >= OSE_BUNDLE_HEADER_LEN) */
/*         { */
/*             return ose_enter(ose_exit(bb), "/_t"); */
/*         } */
/*         bb = ose_exit(bb); */
/*     } */
/*     ose_assert(0); */
/*     return B; */
/* } */

static const void *getTypeFn(ose_constbundle tx,
                             const char typetag,
                             const char * const addr)
{
    const char * const b = ose_getBundlePtr(tx);
    int32_t oo = OSE_BUNDLE_HEADER_LEN;
    int32_t ss = ose_readSize(tx);
    while(oo < ss)
    {
        if(b[oo + 5] == typetag)
        {
            for(int i = 0; i < 5; ++i)
            {
                if(b[oo + 7] == addr[1]
                   && b[oo + 8] == addr[2]
                   && b[oo + 9] == addr[3]
                   && b[oo + 10] == addr[4])
                {
                    return ose_readAlignedPtr(tx, (oo + 4 + ose_readInt32(tx, oo)) - sizeof(intptr_t));

                }
                oo += 4 + 8 + 4 + 12;
            }
        }
        oo += (4 + 8 + 4 + 12) * 5;
        /* oo += ose_readInt32(tx, oo) + 4; */
    }
    return NULL;
}

void osesdk_evalType_hook(ose_bundle osevm)
{
    ose_bundle vm_s = OSEVM_STACK(osevm);
    char typetag;
    int32_t o, s, n;
    ose_bundle tx = ose_getTypeBundle(vm_s);
    /* ose_bundle tx = getTypeBundle(osevm); */
    enum ose_errno e = ose_getLastBundleElem(vm_s, &n, &o, &s);
    if(e)
    {
        ose_errno_set(osevm, e);
        return;
    }
    if(ose_getBundleElemType(vm_s, o) == OSETT_BUNDLE)
    {
        typetag = OSETT_BUNDLE;
    }
    else
    {
        typetag = ose_peekMessageArgTypeAtOffset(vm_s, o);
    }
    void (*fn)(ose_bundle) =
        (void (*)(ose_bundle))getTypeFn(tx, typetag, OSEVM_TYPE_ADDR_EVALTYPE_SUFFIX);
    if(fn)
    {
    	fn(osevm);
    }
}

int32_t osesdk_getPayloadItemLength_hook(ose_bundle bundle,
                                        const char typetag,
                                        const int32_t msg_offset,
                                        const int32_t item_offset)
{
    ose_bundle tx = ose_getTypeBundle(bundle);
	/* ose_bundle tx = getTypeBundle(bundle); */
    ose_getPayloadItemLengthFn fn =
        (ose_getPayloadItemLengthFn)getTypeFn(tx, typetag,
                                              OSE_TYPE_ADDR_GETPAYLOADITEMLENGTH_SUFFIX);
    if(fn)
    {
    	return fn(bundle, typetag, msg_offset, item_offset);
    }
    else
    {
        return -1;
    }
}

int32_t osesdk_getPayloadItemSize_hook(ose_bundle bundle,
                                      const char typetag,
                                      const int32_t msg_offset,
                                      const int32_t item_offset)
{
    ose_bundle tx = ose_getTypeBundle(bundle);
    /* ose_bundle tx = getTypeBundle(bundle); */
    ose_getPayloadItemSizeFn fn =
        (ose_getPayloadItemSizeFn)getTypeFn(tx, typetag,
                                              OSE_TYPE_ADDR_GETPAYLOADITEMSIZE_SUFFIX);
    if(fn)
    {
    	return fn(bundle, typetag, msg_offset, item_offset);
    }
    else
    {
        return -1;
    }
}

int32_t osesdk_pprintPayloadItem_hook(ose_bundle bundle,
                                     const char typetag,
                                     const int32_t msg_offset,
                                     const int32_t item_offset)
{
    ose_bundle tx = ose_getTypeBundle(bundle);
	/* ose_bundle tx = getTypeBundle(bundle); */
    ose_pprintPayloadItemFn fn =
        (ose_pprintPayloadItemFn)getTypeFn(tx, typetag,
                                           OSE_TYPE_ADDR_PPRINTPAYLOADITEM_SUFFIX);
    if(fn)
    {
    	return fn(bundle, typetag, msg_offset, item_offset);
    }
    else
    {
        return -1;
    }
}

int32_t osesdk_fromString_hook(ose_bundle bundle,
                               const char typetag,
                               const char * const str)
{
    __builtin_debugtrap();
}

