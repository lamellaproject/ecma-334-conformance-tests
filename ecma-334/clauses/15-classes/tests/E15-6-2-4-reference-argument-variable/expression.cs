/*
Rules: E15-6-2-4-reference-argument-variable
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: Read(ref Make())
Into: Read(ref value)
Csc: CS1510
*/
class Program
{
    static int Make() { return 37; }
    static int Read(ref int value) { return value; }
    static void Main() { int value = 37; Read(ref Make()); }
}
