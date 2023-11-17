CXXEXT ?= cpp

CFILES ?= ose_$(BASENAME).c

INCLUDES += -I. -I$(LIBOSEDIR)/..

o.se.$(BASENAME).so: $(CFILES:.c=.o) $(CXXFILES:.$(CXXEXT)=.o) $(OTHERDEPS)
	$(CXX) $(LDFLAGS) -shared -o $@ $^ $(OTHERLINKOBJS)

$(CXXFILES:.$(CXXEXT)=.o): %.o: %.$(CXXEXT) $(OTHERCXXFILEDEPS)
	$(CXX) -c $(CXXFLAGS) $(INCLUDES) $(DEFINES) $< -o $@

$(CFILES:.c=.o): %.o: %.c $(OTHERCFILEDEPS)
	$(CC) -c $(CFLAGS) $(INCLUDES) $(DEFINES) $< -o $@

.PHONY: clean
clean:
	rm -rf *.o *.so *.dSYM $(OTHERCLEAN)
