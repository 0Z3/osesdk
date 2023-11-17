#include "osesdk_lookup.h"
#include "libose/ose_context.h"
#include "libose/ose_util.h"
#include "libose/ose_stackops.h"
#include "libose/ose_vm.h"
#include "libose/ose_assert.h"

void osesdk_lookup(ose_bundle osevm)
{
    ose_bundle vm_s = OSEVM_STACK(osevm);
    ose_bundle vm_e = OSEVM_ENV(osevm);
    ose_bundle vm_x = ose_enter(osevm, "/_x");
    ose_bundle bndlenv = vm_e;
    int explicitbndl = 0;

    /* if(ose_peekType(vm_s) != OSETT_MESSAGE */
    /*    || !ose_isStringType(ose_peekMessageArgType(vm_s))) */
    /* { */
    /*     return; */
    /* } */
    /* const char * const address = ose_peekString(vm_s); */
    int32_t o, s, n;
    enum ose_errno e = ose_getLastBundleElem(vm_s, &n, &o, &s);
    if(e != OSE_ERR_NONE)
    {
        return;
    }
    if(ose_getBundleElemType(vm_s, o) != OSETT_MESSAGE)
    {
        return;
    }
    int32_t tto, ntt, lto, po, lpo;
    ose_getNthPayloadItem(vm_s, 1, o, &tto, &ntt, &lto, &po, &lpo);
    if(ose_readByte(vm_s, lto) != OSETT_STRING)
    {
        return;
    }
    const char * const address = ose_getBundlePtr(vm_s) + lpo;
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
        int32_t mo = ose_context_getFirstOffsetForMatch(bndlenv,
                                                        address + 3);
        if(mo >= OSE_BUNDLE_HEADER_LEN)
        {
            ose_dropAtOffset(vm_s, o);
            ose_copyElemAtOffset(mo, bndlenv, vm_s);
            return;
        }
    }
    else
    {
        int32_t mo = ose_context_getFirstOffsetForMatch(vm_e, address);
        if(mo >= OSE_BUNDLE_HEADER_LEN)
        {
            ose_dropAtOffset(vm_s, o);
            ose_copyElemAtOffset(mo, vm_e, vm_s);
            return;
        }
        /* if it wasn't present in env, lookup in _x */
        mo = ose_context_getFirstOffsetForMatch(vm_x, address);
        if(mo >= OSE_BUNDLE_HEADER_LEN)
        {
            ose_dropAtOffset(vm_s, o);
            ose_copyElemAtOffset(mo, vm_x, vm_s);
            return;
        }
    }
}
