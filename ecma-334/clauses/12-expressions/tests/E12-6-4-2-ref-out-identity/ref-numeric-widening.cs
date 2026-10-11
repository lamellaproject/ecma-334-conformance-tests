/*
Rules: E12-6-4-2-ref-out-identity
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: int value = 2;
Into: long value = 2;
*/
class Program
{
    static void Pick(ref long x) { }
    static void Main() { int value = 2; Pick(ref value); }
}
