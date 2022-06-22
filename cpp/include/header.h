#include <cstdint>

#ifdef _DLL
#define DLLEXPORT __declspec(dllexport)
#else
#define DLLEXPORT
#endif

extern "C"
{
std::int32_t DLLEXPORT Sum(std::int32_t a, std::int32_t b);

using FnSum = std::int32_t (*)(std::int32_t, std::int32_t);

std::int32_t DLLEXPORT Sum2(FnSum fn, std::int32_t a, std::int32_t b);

void DLLEXPORT print_text(const char *text);

struct NativeFunctionTable
{
    void (*Destroy)(void *);
    std::int32_t (*GetValue)(void *);
    void (*SetValue)(void *, int32_t);
    void (*Print)(void *);
};

const NativeFunctionTable DLLEXPORT *GetFunctionTable();

void DLLEXPORT *CreateNativeContext();

void DLLEXPORT TestCallback(const NativeFunctionTable *funcTable, void *context);

}