/*
Rules: E8-8-unmanaged-no-type-parameter
Authority: ECMA-334 7th ed 8.8
Version: 7.3
Expected: reject
Mutate: T* pointer = stackalloc T[1];
Into: int* pointer = stackalloc int[1];
*/
class Program { static unsafe void Need<T>() { T* pointer = stackalloc T[1]; } static void Main() { Need<int>(); } }
