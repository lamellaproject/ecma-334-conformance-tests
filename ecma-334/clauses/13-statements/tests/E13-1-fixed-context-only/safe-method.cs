/*
Rules: E13-1-fixed-context-only
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: reject
Mutate: static void Pin()
Into: static unsafe void Pin()
*/
class Program
{
    static void Pin() { int[] data = { 2 }; fixed (int* pointer = data) { } }
    static void Main() { }
}
