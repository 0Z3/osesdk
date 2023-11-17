CSC = csc

EXAMPLE_FILES = hello.cs
EXAMPLE_EXES = $(EXAMPLE_FILES:.cs=.exe)

OSESDKDIR := ../..
SOURCEDIR := $(OSESDKDIR)/source
LIBOSEDIR := $(SOURCEDIR)/libose
INCLUDESDIR := $(OSESDKDIR)/includes
CSHARPSOURCEDIR := $(SOURCEDIR)/csharp

############################################################
# Flags and options
############################################################
TYPES=\
	-DOSE_CONF_PROVIDE_TYPE_DOUBLE \
	-DOSE_CONF_PROVIDE_TYPE_TIMETAG 
#	-DOSE_CONF_PROVIDE_TYPE_SYMBOL \
	-DOSE_CONF_PROVIDE_TYPE_INT8 \
	-DOSE_CONF_PROVIDE_TYPE_UINT8 \
	-DOSE_CONF_PROVIDE_TYPE_INT16 \
	-DOSE_CONF_PROVIDE_TYPE_UINT16 \
	-DOSE_CONF_PROVIDE_TYPE_UINT32 \
	-DOSE_CONF_PROVIDE_TYPE_INT64 \
	-DOSE_CONF_PROVIDE_TYPE_UINT64 \
	-DOSE_CONF_PROVIDE_TYPE_TRUE \
	-DOSE_CONF_PROVIDE_TYPE_FALSE \
	-DOSE_CONF_PROVIDE_TYPE_NULL \
	-DOSE_CONF_PROVIDE_TYPE_INFINITUM

# VM_BUNDLE_SIZE=8388608
VM_BUNDLE_SIZE := 1048576
VM_BUNDLE_SIZES := \
	-DOSE_CONF_VM_INPUT_SIZE=$(VM_BUNDLE_SIZE) \
	-DOSE_CONF_VM_STACK_SIZE=$(VM_BUNDLE_SIZE) \
	-DOSE_CONF_VM_ENV_SIZE=$(VM_BUNDLE_SIZE) \
	-DOSE_CONF_VM_CONTROL_SIZE=$(VM_BUNDLE_SIZE) \
	-DOSE_CONF_VM_DUMP_SIZE=$(VM_BUNDLE_SIZE)

DEFINES := \
	$(VM_BUNDLE_SIZES) \
	$(TYPES) \
	-DHAVE_OSE_ENDIAN_H \
	-DHAVE_OSE_VERSION_H \
	-DOSEVM_LOOKUP=osesdk_lookup \
	-DOSEVM_EVALTYPE=osesdk_evalType \
	-DOSE_GETPAYLOADITEMLENGTH_HOOK=osevm_getPayloadItemLength_hook \
	-DOSE_GETPAYLOADITEMSIZE_HOOK=osevm_getPayloadItemSize_hook \
	-DOSE_PPRINTPAYLOADITEM_HOOK=osevm_pprintPayloadItem_hook \
	-DOSE_CONF_WRAP_BUNDLE_PTR

INCLUDES = -I. -I$(LIBOSEDIR) -I$(INCLUDESDIR)

CFLAGS_DEBUG = -Wall -DOSE_CONF_DEBUG -O0 -g  $(INCLUDES) $(DEFINES)
CFLAGS_RELEASE = -Wall -O3  $(INCLUDES) $(DEFINES)

LDFLAGS = -lm -ldl -rdynamic -Wl,-export_dynamic \
-Wl,-U,_osesdk_lookup \
-Wl,-U,_osesdk_evalType \
-Wl,-U,_osevm_getPayloadItemLength_hook \
-Wl,-U,_osevm_getPayloadItemSize_hook \
-Wl,-U,_osevm_pprintPayloadItem_hook

############################################################
# Environment
############################################################
ENVIRONMENT = \
			CFLAGS="$(CFLAGS)" \
			CXXFLAGS="$(CXXFLAGS)" \
			LDFLAGS="$(LDFLAGS) $(LD_UNDEF_FLAGS)" \
			DEFINES="$(DEFINES)" \
			OSESDKDIR="$(OSESDKDIR)" \
			LIBOSEDIR="$(LIBOSEDIR)" \
			INCLUDES="-I$(LIBOSEDIR) -I$(INCLUDESDIR) -I$(SOURCEDIR)"

############################################################
# Targets
############################################################
all: release

debug: CFLAGS = $(CFLAGS_DEBUG)
debug: CXXLAGS = $(CFLAGS_DEBUG) --std=c++17
debug: libose.so $(EXAMPLE_EXES)

release: CFLAGS = $(CFLAGS_RELEASE)
release: CXXFLAGS = $(CFLAGS_RELEASE) --std=c++17
release: libose.so $(EXAMPLE_EXES)

%.exe: %.cs
	$(CSC) $(CSHARPSOURCEDIR)/*.cs $<

$(SOURCEDIR)/libosesdk.a:
	cd $(OSESDKDIR) && $(ENVIRONMENT) $(MAKE)

libose.so: $(SOURCEDIR)/libosesdk.a $(CSHARPSOURCEDIR)/libose_wrap_csharp.o
	$(CXX) $(CXXFLAGS) $(LDFLAGS) -shared -o $@ $^

$(CSHARPSOURCEDIR)/libose_wrap_csharp.o:
	cd $(CSHARPSOURCEDIR) && $(ENVIRONMENT) $(MAKE)

clean: 
	rm -rf $(EXAMPLE_EXES) libose.so
