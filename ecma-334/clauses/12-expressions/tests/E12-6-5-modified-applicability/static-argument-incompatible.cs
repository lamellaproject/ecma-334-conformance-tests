/*
Rules: E12-6-5-modified-applicability; E12-6-5-limited-check; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: Pick("label", value);
Into: Pick(3, value);
Csc: CS1503
*/
class Program
{
    static void Pick(int first, int second) { }
    static void Main()
    {
        dynamic value = 8;
        Pick("label", value);
    }
}
