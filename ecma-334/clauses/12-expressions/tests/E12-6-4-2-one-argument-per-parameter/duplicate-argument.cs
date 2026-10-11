/*
Rules: E12-6-4-2-one-argument-per-parameter
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Pick(1, first: 2)
Into: Pick(1, second: 2)
*/
class Program
{
    static void Pick(int first, int second) { }
    static void Main() { Pick(1, first: 2); }
}
