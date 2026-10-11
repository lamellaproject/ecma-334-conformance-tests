/*
Rules: E12-6-4-1-ambiguous-best; E12-6-4-3-no-better-member
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: reject
Mutate: Pick(3, 5)
Into: Pick(3L, 5)
*/
class Program
{
    static void Pick(int x, long y) { }
    static void Pick(long x, int y) { }
    static void Main() { Pick(3, 5); }
}
