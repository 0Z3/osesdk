ifeq ($(OS),Windows_NT)
OSNAME := $(OS)
else
OSNAME := $(shell uname -s)
endif

SOURCEDIR = ./source
INCLUDESDIR = ./includes

STATIC_TARGET = $(SOURCEDIR)/libosesdk.a

.PHONY: all csharp
all: $(STATIC_TARGET) csharp

LIBOSEDIR=$(SOURCEDIR)/libose

############################################################
# libose.a
############################################################

$(LIBOSEDIR)/libose.a:
	@cd $(LIBOSEDIR) && CFLAGS="$(CFLAGS)" LDFLAGS="$(LDFLAGS)" $(MAKE)

############################################################
# libosesdk.a
############################################################

ifeq ($(OSNAME),Darwin)
STATIC_TARGET_CMD = libtool -static -o $(STATIC_TARGET) $(OFILES) $(LIBOSEDIR)/libose.a
else
STATIC_TARGET_CMD = ar rcs $(STATIC_TARGET) $(OFILES) $(LIBOSEDIR)/*.o
endif

CFILES += \
$(SOURCEDIR)/osesdk_lookup.c \
$(SOURCEDIR)/osesdk_types.c \
$(SOURCEDIR)/osesdk_load.c \
$(SOURCEDIR)/osesdk_rax.c \
$(SOURCEDIR)/thirdparty/rax/rax.c \
$(SOURCEDIR)/thirdparty/rax/rc4rand.c \
$(SOURCEDIR)/thirdparty/rax/crc16.c

OFILES = $(CFILES:.c=.o)

INCLUDES += -I$(SOURCEDIR) -I$(INCLUDESDIR) -I$(LIBOSEDIR) -I$(SOURCEDIR)/thirdparty

%.o: %.c
	$(CC) $(CFLAGS) -c $(INCLUDES) -o $@ $<

$(STATIC_TARGET): $(LIBOSEDIR)/libose.a $(OFILES)
	$(STATIC_TARGET_CMD)
#	libtool -static -o $(STATIC_TARGET) $(OFILES) $(LIBOSEDIR)/libose.a

############################################################
# Csharp
############################################################
.PHONY: clean libose-clean
clean:
	rm -rf $(SOURCEDIR)/libosesdk.a
	rm -rf $(SOURCEDIR)/*.o
	cd $(SOURCEDIR)/thirdparty/rax && $(MAKE) clean

libose-clean:
	cd $(LIBOSEDIR) && $(MAKE) clean

############################################################
# Csharp
############################################################

CSHARP_SOURCE=$(SOURCEDIR)/csharp
CSHARP_EXAMPLES=examples/csharp

csharp:
	cd $(CSHARP_EXAMPLES) && $(MAKE)

csharp-clean:
	cd $(CSHARP_SOURCE) && $(MAKE) clean
	cd $(CSHARP_EXAMPLES) && $(MAKE) clean

