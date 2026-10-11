/*
Rules: E12-6-5-explicit-type-substitution; E12-6-5-modified-applicability; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: Pick<int>("label", value);
Into: Pick<string>("label", value);
Csc: CS1503
*/
class Program
{
    static void Pick<T>(T first, int second) { }
    static void Main()
    {
        dynamic value = 3;
        Pick<int>("label", value);
    }
}
