/*
Rules: E8-8-unmanaged-no-reference-type
Authority: ECMA-334 7th ed 8.8
Version: 7.3
Expected: reject
Mutate: object* pointer = stackalloc object[1];
Into: int* pointer = stackalloc int[1];
*/
class Program { static unsafe void Main() { object* pointer = stackalloc object[1]; } }
