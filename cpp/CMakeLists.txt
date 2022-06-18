cmake_minimum_required(VERSION 3.22)
project(CppSharpSampleNative)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_GENERATOR_TOOLSET "v143")

include_directories(include)
add_library(CppSharpSampleNative SHARED src/source.cpp include/header.h)
