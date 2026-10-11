/*
Rules: E12-6-4-1-no-applicable; E12-6-4-2-value-conversion
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: reject
Mutate: Pick(7L)
Into: Pick(7)
*/
class Program
{
    static void Pick(int x) { }
    static void Pick(string x) { }
    static void Main() { Pick(7L); }
}
