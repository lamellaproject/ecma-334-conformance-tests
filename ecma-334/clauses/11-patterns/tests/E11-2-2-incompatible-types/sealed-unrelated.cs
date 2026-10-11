/*
Rules: E11-2-2-incompatible-types; E11-2-1-inapplicable-pattern
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: reject
Mutate: source is string value
Into: source is int value
*/
class Program
{
    static void Main()
    {
        int source = 29;
        if (source is string value) { }
    }
}
