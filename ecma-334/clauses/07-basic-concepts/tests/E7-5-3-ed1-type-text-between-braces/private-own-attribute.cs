/*
Rules: E7-5-3-ed1-type-text-between-braces
Authority: ECMA-334 1st ed 10.5.2
Version: ISO-1
Expected: reject
Version-Witness: tests/E7-5-3-ed1-type-text-between-braces/private-own-attribute.witness.cs.part
Mutate: private const int Code
Into: public const int Code
*/
// ECMA-334 1st ed 10.5.2, p. 74-75 (PDF p. 88, 89), lines 44-45 and 1-2. For member
// accessibility domains, the program text of a type is the source text between its body
// braces, including nested types.
public sealed class ImprintAttribute : System.Attribute
{
    public ImprintAttribute(int number)
    {
    }
}

[ImprintAttribute(Casket.Code)]
class Casket
{
    private const int Code = 31;
}

class Observe
{
    static int Main()
    {
        System.Console.WriteLine("OK 0");
        return 0;
    }
}
