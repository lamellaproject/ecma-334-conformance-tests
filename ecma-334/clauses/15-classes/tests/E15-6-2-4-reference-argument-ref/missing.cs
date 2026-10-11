/*
Rules: E15-6-2-4-reference-argument-ref
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: Read(value)
Into: Read(ref value)
Csc: CS1620
*/
class Program
{
    static int Read(ref int value) { return value; }
    static void Main() { int value = 29; Read(value); }
}
