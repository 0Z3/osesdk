%module(directors="1") libose

%include "libose.i"

%include "stdint.i"
%include "typemaps.i"

%include "arrays_csharp.i"
%include "carrays.i"
%apply unsigned char INPUT[]  {unsigned char *packet}
%apply unsigned char INPUT[]  {unsigned char *dest}

%{
	#include "OSEBase.h"
%}

%feature("director") OSEBase;
%include "OSEBase.h"
