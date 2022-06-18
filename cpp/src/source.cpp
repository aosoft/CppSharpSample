#include "header.h"


std::int32_t DLLEXPORT Sum(std::int32_t a, std::int32_t b) {
    return a + b;
}

std::int32_t DLLEXPORT Sum2(FnSum *fn, std::int32_t a, std::int32_t b) {
    return fn != nullptr ? (*fn)(a, b) : 0;
}
