/*
Rules: E7-6-byref-only-overload-forbidden
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: Read(in int value)
Into: Read(int value)
*/
class Program
{
    static int Read(ref int value) { return value; }
    static int Read(in int value) { return value; }
    static void Main() { }
}
