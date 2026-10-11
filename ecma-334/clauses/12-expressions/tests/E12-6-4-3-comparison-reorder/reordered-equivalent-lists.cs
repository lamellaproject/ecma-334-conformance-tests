/*
Rules: E12-6-4-3-comparison-reorder
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: reject
Mutate: Pick(last: 5, first: 3)
Into: Pick(3, 5L)
*/
class Program
{
    static void Pick(int first, long last) { }
    static void Pick(long last, int first) { }
    static void Main() { Pick(last: 5, first: 3); }
}
