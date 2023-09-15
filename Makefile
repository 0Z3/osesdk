.PHONY: all csharp libose-clean csharp-clean
all: csharp
clean: libose-clean csharp-clean

LIBOSE_DIR=source/libose

CSHARP_SOURCE=source/csharp
CSHARP_EXAMPLES=examples/csharp

csharp:
	cd $(CSHARP_SOURCE) && $(MAKE)
	cd $(CSHARP_EXAMPLES) && $(MAKE)

csharp-clean:
	cd $(CSHARP_SOURCE) && $(MAKE) clean
	cd $(CSHARP_EXAMPLES) && $(MAKE) clean

libose-clean:
	cd $(LIBOSE_DIR) && $(MAKE) clean
