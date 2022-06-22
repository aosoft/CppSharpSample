#include "header.h"
#include <stdio.h>

std::int32_t DLLEXPORT Sum(std::int32_t a, std::int32_t b) {
    return a + b;
}

std::int32_t DLLEXPORT Sum2(FnSum fn, std::int32_t a, std::int32_t b) {
    return fn != nullptr ? (*fn)(a, b) : 0;
}

void DLLEXPORT print_text(const char *text) {
    printf("print_text - %s\n", text);
}

class NativeClass {
private:
    std::int32_t _value;

public:

    NativeClass() {
        _value = 0;
    }

    void Destroy() {
        delete this;
    }

    std::int32_t GetValue() {
        return _value;
    }

    void SetValue(int32_t value) {
        _value = value;
    }

    void Print() {
        printf("NativeClass Value = %d\n", _value);
    }
};

template<typename T, typename TRet, typename ... Args>
struct Proxy {
    template<typename TRet(T::*func)(Args...)>
    static TRet Func(void *context, Args... args) {
        return (reinterpret_cast<T *>(context)->*func)(args...);
    }
};

const NativeFunctionTable DLLEXPORT *GetFunctionTable(){
    static const NativeFunctionTable Table = {
        Proxy<NativeClass, void>::Func<&NativeClass::Destroy>,
        Proxy<NativeClass, std::int32_t>::Func<&NativeClass::GetValue>,
        Proxy<NativeClass, void, std::int32_t>::Func<&NativeClass::SetValue>,
        Proxy<NativeClass, void>::Func<&NativeClass::Print>
    };
    return &Table;
}


void DLLEXPORT *CreateNativeContext() {
    return new NativeClass();
}

void DLLEXPORT TestCallback(const NativeFunctionTable *funcTable, void *context) {
    (*funcTable->SetValue)(context, 10);
    printf("%d\n", (*funcTable->GetValue)(context));
    (*funcTable->Print)(context);
}