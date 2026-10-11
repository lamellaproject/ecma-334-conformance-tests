/*
Rules: E12-9-1-indirection-unsafe-only
Authority: ECMA-334 7th ed 12.9.1
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
*/
class Program
{
    static unsafe int* Pointer() { return null; }
    static void Main() { if (false) { int result = *Pointer(); } }
}
