/*
Rules: E12-6-4-2-expanded-too-few
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Pick(1)
Into: Pick(1, 2)
*/
class Program
{
    static void Pick(int first, int second, params int[] tail) { }
    static void Main() { Pick(1); }
}
