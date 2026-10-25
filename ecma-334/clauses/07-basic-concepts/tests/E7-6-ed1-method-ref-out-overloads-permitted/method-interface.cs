/*
Rules: E7-6-ed1-method-ref-out-overloads-permitted
Authority: ECMA-334 1st ed 10.6
Version: ISO-1
Expected: run
Stdout: OK 0
Version-Witness: tests/E7-6-ed1-method-ref-out-overloads-permitted/method-interface-witness.cs.part
Mutate: out short result
Into: ref short result
*/
// ECMA-334 1st ed 10.6, p. 79 (PDF p. 93), lines 1-2. Permit same-type method overload
// declarations distinguished by reference versus output parameter mode in a class, struct,
// or interface.

interface PolishContract
{
    void Polish(ref short input);
    void Polish(out short result);
}

class DeclarationEntry
{
    public static int Main()
    {
        System.Console.WriteLine("OK 0");
        return 0;
    }
}
