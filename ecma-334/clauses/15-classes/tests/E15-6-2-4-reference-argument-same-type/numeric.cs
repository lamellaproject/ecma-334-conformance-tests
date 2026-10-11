/*
Rules: E15-6-2-4-reference-argument-same-type
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: byte value = 43;
Into: long value = 43;
Csc: CS1503
*/
class Program
{
    static long Read(ref long value) { return value; }
    static void Main() { byte value = 43; Read(ref value); }
}
