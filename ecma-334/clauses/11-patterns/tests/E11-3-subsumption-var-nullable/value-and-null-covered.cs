/*
Rules: E11-3-subsumption-var-nullable; E11-3-subsumed-case
Authority: ECMA-334 7th ed 11.3
Version: 7.3
Expected: reject
Mutate: case int first: return 1;
Into: case int first when first < 0: return 1;
*/
class Program
{
    static int Select(int? input)
    {
        switch (input)
        {
            case int first: return 1;
            case null: return 2;
            case var rest: return 3;
            default: return -1;
        }
    }
    static void Main() { }
}
