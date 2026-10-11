/*
Rules: E15-6-2-4-reference-argument-variable
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: Read(ref 41)
Into: Read(ref value)
Csc: CS1510
*/
class Program
{
    static int Read(ref int value) { return value; }
    static void Main() { int value = 41; Read(ref 41); }
}
