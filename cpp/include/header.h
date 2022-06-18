#include <cstdint>

#ifdef _DLL
#define DLLEXPORT __declspec(dllexport)
#else
#define DLLEXPORT
#endif

extern "C"
{
std::int32_t DLLEXPORT Sum(std::int32_t a, std::int32_t b);

}