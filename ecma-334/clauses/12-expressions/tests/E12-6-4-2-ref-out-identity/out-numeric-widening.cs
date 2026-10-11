/*
Rules: E12-6-4-2-ref-out-identity
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: long value;
Into: int value;
*/
class Program
{
    static void Pick(out int x) { x = 2; }
    static void Main() { long value; Pick(out value); }
}
