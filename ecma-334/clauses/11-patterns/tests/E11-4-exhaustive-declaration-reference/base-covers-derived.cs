/*
Rules: E11-4-exhaustive-declaration-reference; E11-3-subsumption-declaration
Authority: ECMA-334 7th ed 11.4
Version: 7.3
Expected: reject
Mutate: case Parent first: return 1;
Into: case Parent first when false: return 1;
*/
class Parent { }
class Child : Parent { }
class Program
{
    static int Select(object input)
    {
        switch (input)
        {
            case Parent first: return 1;
            case Child second: return 2;
            default: return -1;
        }
    }
    static void Main() { }
}
