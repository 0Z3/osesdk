CSHARP_SOURCE=../../source/csharp
CSHARP_EXAMPLES=.
CSC=csc

EXAMPLE_FILES=hello.cs
EXAMPLE_EXES=$(EXAMPLE_FILES:.cs=.exe)

all: $(EXAMPLE_EXES) libose.so

%.exe: %.cs
	$(CSC) $(CSHARP_SOURCE)/*.cs $<

libose.so:
	cp $(CSHARP_SOURCE)/libose.so .

clean: 
	rm -rf $(EXAMPLE_EXES) libose.so
