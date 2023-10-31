#include <stdio.h> // for snprintf

#include "osesdk_types.h"
#include "libose/ose_context.h"
#include "libose/ose_util.h"
#include "libose/ose_stackops.h"
#include "libose/ose_vm.h"

void osesdk_evalType(ose_bundle osevm)
{
    ose_bundle vm_s = OSEVM_STACK(osevm);
    if(ose_peekType(vm_s) == OSETT_BUNDLE)
    {
        char buf[OSEVM_EVALTYPE_ADDR_LEN];
        int32_t len = snprintf(buf, OSEVM_EVALTYPE_ADDR_LEN,
                               OSEVM_EVALTYPE_ADDR, OSETT_BUNDLE);
        ose_pushString(vm_s, buf);
        OSEVM_LOOKUP(osevm);
        if(ose_peekMessageArgType(vm_s) == OSETT_BLOB)
        {
            osevm_apply(osevm);
        }
        else
        {
            ose_drop(vm_s);
        }
    }
    else
    {
        char tt = ose_peekMessageArgType(vm_s);
        char buf[OSEVM_EVALTYPE_ADDR_LEN];
        int32_t len = snprintf(buf, OSEVM_EVALTYPE_ADDR_LEN,
                               OSEVM_EVALTYPE_ADDR, tt);
        ose_pushString(vm_s, buf);
        OSEVM_LOOKUP(osevm);
        if(ose_peekMessageArgType(vm_s) == OSETT_BLOB)
        {
            osevm_apply(osevm);
        }
        else
        {
            ose_drop(vm_s);
        }
    }
}
