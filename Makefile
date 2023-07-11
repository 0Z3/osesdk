.PHONY: all csharp csharp-clean
all: csharp
clean: csharp-clean

CSHARP_SOURCE=source/csharp
CSHARP_EXAMPLES=examples/csharp

csharp:
	cd $(CSHARP_SOURCE) && $(MAKE)
	cd $(CSHARP_EXAMPLES) && $(MAKE)

csharp-clean:
	cd $(CSHARP_SOURCE) && $(MAKE) clean
	cd $(CSHARP_EXAMPLES) && $(MAKE) clean
