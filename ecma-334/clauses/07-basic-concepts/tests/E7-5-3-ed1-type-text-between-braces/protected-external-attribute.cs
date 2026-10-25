/*
Rules: E7-5-3-ed1-type-text-between-braces
Authority: ECMA-334 1st ed 10.5.2
Version: ISO-1
Expected: reject
Fixture: {"libraries":[{"name":"Reference","units":[{"source":"tests/E7-5-3-ed1-type-text-between-braces/protected-external-attribute-library.cs.part"}]}],"program":{"references":[{"library":"Reference"}]}}
Version-Witness: tests/E7-5-3-ed1-type-text-between-braces/protected-external-attribute.witness.cs.part
Mutate: Timber.Code
Into: 47
*/
// ECMA-334 1st ed 10.5.2, p. 74-75 (PDF p. 88, 89), lines 44-45 and 1-2. For member
// accessibility domains, the program text of a type is the source text between its body
// braces, including nested types.
[ImprintAttribute(Timber.Code)]
class Shoot : Timber
{
}

class Observe
{
    static int Main()
    {
        System.Console.WriteLine("OK 0");
        return 0;
    }
}
