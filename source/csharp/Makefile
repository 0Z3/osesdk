############################################################
# Variables setable from the command line:
#
# CCOMPILER (default: clang)
# DEBUG_SYMBOLS (default: DWARF)
# EXTRA_CFLAGS (default: none)
############################################################

ifndef CCOMPILER
CC=clang
CPP=clang++
else
CC=$(CCOMPILER)
CPP=$(CPPCOMPILER)
endif

ifeq ($(OS),Windows_NT)
OSNAME:=$(OS)
else
OSNAME:=$(shell uname -s)
endif

LIBOSEDIR:=../libose
COMMONDIR:=../common

CFILENAMES+=\
ose.c\
ose_context.c\
ose_match.c\
ose_print.c\
ose_stackops.c\
ose_util.c\
ose_vm.c\
osevm_lib.c

CFILES=$(foreach f,$(CFILENAMES),$(LIBOSEDIR)/$(f))

HFILES:=$(CFILES:.c=.h) ose_conf.h $(LIBOSEDIR)/sys/ose_endian.h $(LIBOSEDIR)/ose_version.h

OFILES=$(CFILENAMES:.c=.o)

DEFINES+=\
	-DHAVE_OSE_ENDIAN_H \
	-DHAVE_OSE_VERSION_H

# CSTD=c99
CSTD=c89

STATIC_TARGET:=libose.a

ifeq ($(OSNAME),Darwin)
STATIC_TARGET_CMD=libtool -static -o $(STATIC_TARGET) $(OFILES)
else
STATIC_TARGET_CMD=ar rcs $(STATIC_TARGET) $(OFILES)
endif

DYNAMIC_TARGET:=libose.so
DYNAMIC_TARGET_CMD=$(CC) $(LDFLAGS) $(OFILES) -shared -o $(DYNAMIC_TARGET)

.PHONY: all csharp
all: csharp

INCLUDES=-I. -I$(COMMONDIR) -I$(LIBOSEDIR)

ifneq ($(OS),Windows_NT)
CFLAGS:=-fPIC
endif

libose_wrap_csharp.cxx: $(LIBOSEDIR)/sys/ose_endian.h $(LIBOSEDIR)/ose_version.h $(COMMONDIR)/libose.i
	swig -csharp \
	-c++ \
	-I$(COMMONDIR) -I$(LIBOSEDIR) \
	-o libose_wrap_csharp.cxx \
	csharp.o.se.i

csharp: libose_wrap_csharp.cxx
csharp: libose_wrap_csharp.o
# csharp: CFILES+=libose_wrap_csharp.cxx
csharp: OFILES+=libose_wrap_csharp.o
csharp: CFLAGS+=$(DEFINES) -Wall -O0 -g$(DEBUG_SYMBOLS) -gmodules -c $(EXTRA_CFLAGS)
csharp: DYNAMIC_TARGET_CMD=$(CPP) $(LDFLAGS) $(OFILES) -shared -o $(DYNAMIC_TARGET)
csharp: $(DYNAMIC_TARGET)

%.o: $(LIBOSEDIR)/%.c $(LIBOSEDIR)/%.h
	$(CC) $(CFLAGS) $(INCLUDES) -o $@ $<

libose_wrap_csharp.o: libose_wrap_csharp.cxx $(LIBOSEDIR)/sys/ose_endian.h
	$(CPP) $(CFLAGS) $(INCLUDES) -o $@ $<

$(STATIC_TARGET): $(HFILES) $(OFILES) $(CFILES)
	$(STATIC_TARGET_CMD)

$(DYNAMIC_TARGET): $(OFILES) $(CFILES) $(HFILES)
	$(DYNAMIC_TARGET_CMD)

############################################################
# Derived files
############################################################
#sys/ose_endianchk: CC=clang
$(LIBOSEDIR)/sys/ose_endianchk: $(LIBOSEDIR)/sys/ose_endianchk.c
	$(CC) -o $(LIBOSEDIR)/sys/ose_endianchk $(LIBOSEDIR)/sys/ose_endianchk.c

$(LIBOSEDIR)/sys/ose_endian.h: $(LIBOSEDIR)/sys/ose_endianchk
	$(LIBOSEDIR)/sys/ose_endianchk > $(LIBOSEDIR)/sys/ose_endian.h

$(LIBOSEDIR)/ose_version.h:
	echo "#define OSE_VERSION \""`git describe --always --dirty --tags`"\"" > ose_version.h
	echo "#define OSE_DATE_COMPILED \""`date`"\"" >> $(LIBOSEDIR)/ose_version.h

ose_conf.h:
	touch ose_conf.h

############################################################
# Clean
############################################################
.PHONY: clean
clean: 
	rm -rf $(STATIC_TARGET) $(DYNAMIC_TARGET) *.dSYM $(LIBOSEDIR)/sys/ose_endianchk $(LIBOSEDIR)/sys/ose_endian.h *.o $(LIBOSEDIR)/sys/*.o ose_version.h 
