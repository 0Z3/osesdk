CXXEXT ?= cpp

CFILES ?= ose_$(BASENAME).c

INCLUDES += -I. -I$(LIBOSEDIR)/..

TARGETNAME ?= o.se.$(BASENAME).so

MACROPREFIX ?= $(BASENAME)
VARNAME_VERSION ?= $(MACROPREFIX)_version
VARNAME_DATE_COMPILED ?= $(MACROPREFIX)_date_compiled
VERSION_H ?= $(BASENAME)_version.h

$(TARGETNAME): $(OTHERDEPS) $(CFILES:.c=.o) $(CXXFILES:.$(CXXEXT)=.o)
	echo $(VERSION_H)
	$(CXX) $(LDFLAGS) -o $@ $^ $(OTHERLINKOBJS)

$(CXXFILES:.$(CXXEXT)=.o): %.o: %.$(CXXEXT) $(OTHERCXXFILEDEPS) $(VERSION_H)
	$(CXX) -c $(CXXFLAGS) $(INCLUDES) $(DEFINES) $< -o $@

$(CFILES:.c=.o): %.o: %.c $(OTHERCFILEDEPS) $(VERSION_H)
	$(CC) -c $(CFLAGS) $(INCLUDES) $(DEFINES) $< -o $@

$(VERSION_H):
	echo "static const char * const $(VARNAME_VERSION) = \""`git describe --always --dirty --tags`"\";" > $(VERSION_H)
	echo "static const char * const $(VARNAME_DATE_COMPILED) = \""`date`"\";" >> $(VERSION_H)

.PHONY: clean
clean: $(OTHERCLEANTARGETS)
	rm -rf *.o *.so *.dSYM $(VERSION_H) $(OTHERCLEAN)
