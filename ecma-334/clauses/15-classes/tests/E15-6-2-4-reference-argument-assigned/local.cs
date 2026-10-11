/*
Rules: E15-6-2-4-reference-argument-assigned
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: int value;
Into: int value = 47;
Csc: CS0165
*/
class Program
{
    static int Read(ref int value) { return value; }
    static void Main() { int value; Read(ref value); }
}
