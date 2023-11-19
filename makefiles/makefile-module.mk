CXXEXT ?= cpp

CFILES ?= ose_$(BASENAME).c

INCLUDES += -I. -I$(LIBOSEDIR)/..

TARGETNAME ?= o.se.$(BASENAME).so

$(TARGETNAME): $(OTHERDEPS) $(CFILES:.c=.o) $(CXXFILES:.$(CXXEXT)=.o) 
	$(CXX) $(LDFLAGS) -shared -o $@ $^ $(OTHERLINKOBJS)

$(CXXFILES:.$(CXXEXT)=.o): %.o: %.$(CXXEXT) $(OTHERCXXFILEDEPS)
	$(CXX) -c $(CXXFLAGS) $(INCLUDES) $(DEFINES) $< -o $@

$(CFILES:.c=.o): %.o: %.c $(OTHERCFILEDEPS)
	$(CC) -c $(CFLAGS) $(INCLUDES) $(DEFINES) $< -o $@

.PHONY: clean
clean: $(OTHERCLEANTARGETS)
	rm -rf *.o *.so *.dSYM $(OTHERCLEAN)
