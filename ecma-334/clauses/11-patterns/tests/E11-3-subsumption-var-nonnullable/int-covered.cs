/*
Rules: E11-3-subsumption-var-nonnullable; E11-3-subsumed-case; E11-4-exhaustive-declaration-identity
Authority: ECMA-334 7th ed 11.3
Version: 7.3
Expected: reject
Mutate: case int first: return 1;
Into: case int first when first < 0: return 1;
*/
class Program
{
    static int Select(int input)
    {
        switch (input)
        {
            case int first: return 1;
            case var rest: return 2;
            default: return -1;
        }
    }
    static void Main() { }
}
