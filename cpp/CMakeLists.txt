cmake_minimum_required(VERSION 3.22)
project(CppSharpSample)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_GENERATOR_TOOLSET "v143")

include_directories(include)
add_library(CppSharpSample src/source.cpp include/header.h)
