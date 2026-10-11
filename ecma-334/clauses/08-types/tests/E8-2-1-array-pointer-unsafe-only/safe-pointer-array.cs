/*
Rules: E8-2-1-array-pointer-unsafe-only
Authority: ECMA-334 7th ed 8.2.1
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
*/
class Program { static void Main() { int*[] slots = null; } }
