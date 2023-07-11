%module(directors="1") libose

%include "o.se.i"

%include "stdint.i"
%include "typemaps.i"

%include "arrays_csharp.i"
%include "carrays.i"

%{
	#include "OSECsharpBase.h"
%}

%feature("director") OSECsharpBase;
%include "OSECsharpBase.h"
