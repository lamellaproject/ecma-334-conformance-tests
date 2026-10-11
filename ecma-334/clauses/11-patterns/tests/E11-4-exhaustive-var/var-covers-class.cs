/*
Rules: E11-4-exhaustive-var; E11-3-subsumption-declaration; E11-3-subsumed-case
Authority: ECMA-334 7th ed 11.4
Version: 7.3
Expected: reject
Mutate: case var first: return 1;
Into: case int first: return 1;
*/
class Beacon { }
class Program
{
    static int Select(object input)
    {
        switch (input)
        {
            case var first: return 1;
            case Beacon second: return 2;
            default: return -1;
        }
    }
    static void Main() { }
}
