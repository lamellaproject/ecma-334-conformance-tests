/*
Rules: E12-6-4-2-explicit-in-identity
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Pick(in value)
Into: Pick(value)
*/
class Program
{
    static void Pick(in long x) { }
    static void Main() { int value = 2; Pick(in value); }
}
