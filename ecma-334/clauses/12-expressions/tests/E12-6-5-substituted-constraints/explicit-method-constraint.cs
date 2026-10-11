/*
Rules: E12-6-5-substituted-constraints; E12-6-5-explicit-type-substitution; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: Pick<int>(value);
Into: Pick<string>(value);
Csc: CS0452
*/
class Program
{
    static void Pick<T>(int value) where T : class { }
    static void Main()
    {
        dynamic value = 8;
        Pick<int>(value);
    }
}
