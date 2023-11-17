OSESDKDIR := ../..
SOURCEDIR := $(OSESDKDIR)/source
LIBOSEDIR := $(SOURCEDIR)/libose
INCLUDESDIR := $(OSESDKDIR)/includes
SWIGDIR := $(OSESDKDIR)/wrappers

INCLUDES=-I. -I$(INCLUDESDIR) -I$(LIBOSEDIR) -I$(SOURCEDIR) -I$(SWIGDIR)

csharp: libose_wrap_csharp.o

libose_wrap_csharp.cxx: SWIGCXXFLAGS += $(DEFINES)
libose_wrap_csharp.cxx: $(SWIGDIR)/libose.i
	swig -csharp \
	-c++ \
	$(SWIGCXXFLAGS) \
	$(INCLUDES) \
	-o libose_wrap_csharp.cxx \
	csharp.o.se.i

libose_wrap_csharp.o: libose_wrap_csharp.cxx 
	$(CXX) -c $(CXXFLAGS) $(INCLUDES) -o $@ $<

############################################################
# Clean
############################################################
.PHONY: clean
clean:
	rm -rf *.dSYM *.o *.cs libose_wrap_csharp.*
