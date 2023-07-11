#ifndef OSEBASECSHARP_H
#define OSEBASECSHARP_H

#include "OSEBase.h"

#define THISCLASS OSECsharpBase

OSE_WRAPPER_DECL(println);
OSE_WRAPPER_DECL(sendto);

#pragma SWIG nowarn=462
// Warning 462 from SWIG means that it will not generate
// a wrapper for this struct, which is what we want.
OSE_WRAPPER_TAB_DEFN(
    OSE_WRAPPER_BIND(println),
    OSE_WRAPPER_BIND(sendto)
    );

class OSECsharpBase : public OSEBase
{
public:
    virtual void ose_println(ose_bundle osevm) = 0 ;
    virtual void ose_sendto(ose_bundle osevm) = 0 ;

    void *getfnptr(const char * const fname) override
    {
        for(int i = 0;
            i < OSE_WRAPPER_TAB_LENGTH;
            ++i)
        {
            if(!strcmp(OSE_WRAPPER_TAB[i].name, fname))
            {
                return OSE_WRAPPER_TAB[i].fn;
            }
        }
        return NULL;
    }
};

OSE_WRAPPER_DEFN(println);
OSE_WRAPPER_DEFN(sendto);

#endif
