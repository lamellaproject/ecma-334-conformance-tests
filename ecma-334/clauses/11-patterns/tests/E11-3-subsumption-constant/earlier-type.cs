/*
Rules: E11-3-subsumption-constant; E11-3-subsumed-case; E11-3-would-match-constant
Authority: ECMA-334 7th ed 11.3
Version: 7.3
Expected: reject
Mutate: case int first: return 1;
Into: case int first when first < 0: return 1;
*/
class Program
{
    static int Select(object input)
    {
        switch (input)
        {
            case int first: return 1;
            case 29: return 2;
            default: return -1;
        }
    }
    static void Main() { }
}
