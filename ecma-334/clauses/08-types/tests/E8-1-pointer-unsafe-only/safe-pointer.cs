/*
Rules: E8-1-pointer-unsafe-only
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
*/
class Program { static void Main() { int* pointer = null; } }
