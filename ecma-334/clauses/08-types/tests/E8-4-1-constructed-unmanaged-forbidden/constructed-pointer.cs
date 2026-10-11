/*
Rules: E8-4-1-constructed-unmanaged-forbidden; E8-8-unmanaged-no-constructed-type
Authority: ECMA-334 7th ed 8.4.1
Version: 7.3
Expected: reject
Mutate: Box<int>* pointer
Into: int* pointer
*/
struct Box<T> { public int Value; }
class Program { static unsafe void Main() { Box<int>* pointer = null; } }
