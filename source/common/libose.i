/* %module(directors="1") libose */
%module libose
%include "stdint.i"
%include "typemaps.i"

/* %include "arrays_csharp.i" */
/* %include "carrays.i" */
/* %apply unsigned char INPUT[]  {unsigned char *packet} */
/* %apply unsigned char INPUT[]  {unsigned char *dest} */
/* %apply unsigned char OUTPUT[] {unsigned char *getptrforoffset} */

/* %apply unsigned char INPUT[]  {unsigned char *} */

/* %apply void *VOID_INT_PTR { void * } */

%{
    #include <iostream>
    #include "ose_conf.h"
    #include "ose.h"
    #include "ose_assert.h"
    #include "ose_context.h"
    #include "ose_errno.h"
    #include "ose_match.h"
    #include "ose_print.h"
    #include "ose_stackops.h"
    #include "ose_util.h"
    #include "ose_vm.h"
    #include "osevm_lib.h"

    /* #include "OSEBase.h" */

%}

/* %feature("director") OSEBase; */

/*
  it would be nice to do libose.pushString(...) instead of
  libose.ose_pushString(...), but these filters are likely more
  trouble than they're worth
*/
/* %rename("%(strip:[ose_])s", regexmatch$name="^ose_[a-zA-Z]") ""; */
/* %rename("%(regex:/^ose_2(\\w+)/two\\1/)s") ""; */

%include "ose_conf.h"
%include "ose.h"
%include "ose_assert.h"
%include "ose_context.h"
%include "ose_errno.h"
%include "ose_match.h"
%include "ose_print.h"
%include "ose_stackops.h"
%include "ose_util.h"
%include "ose_vm.h"
%include "osevm_lib.h"

/* %include "OSEBase.h" */
