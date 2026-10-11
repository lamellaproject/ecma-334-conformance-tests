/*
Rules: E12-6-4-2-omitted-optional
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Pick()
Into: Pick(3)
*/
class Program
{
    static void Pick(int required, int optional = 5) { }
    static void Main() { Pick(); }
}
