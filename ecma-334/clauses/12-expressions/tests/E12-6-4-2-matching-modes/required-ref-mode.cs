/*
Rules: E12-6-4-2-matching-modes
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Pick(value)
Into: Pick(ref value)
*/
class Program
{
    static void Pick(ref int x) { }
    static void Main() { int value = 2; Pick(value); }
}
