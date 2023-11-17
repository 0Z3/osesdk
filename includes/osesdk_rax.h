#ifndef OSESDK_RAX_H
#define OSESDK_RAX_H

#include "ose.h"

#ifdef __cplusplus
extern "C" {
#endif

void osesdk_rax_init(ose_bundle bundle, int32_t raxmemsize, char *raxmem);
int32_t osesdk_rax_getFirstOffsetForMatch(ose_bundle bundle,
                                          const char * const address,
                                          void **userdata);
void osesdk_rax_buildTree(ose_bundle bundle,
                          void **userdata);
void *osesdk_rax_malloc(size_t size, void *context);
void *osesdk_rax_realloc(void *ptr, size_t size, void *context);
void osesdk_rax_free(void *ptr, void *context);

#ifdef __cplusplus
}
#endif

#endif
