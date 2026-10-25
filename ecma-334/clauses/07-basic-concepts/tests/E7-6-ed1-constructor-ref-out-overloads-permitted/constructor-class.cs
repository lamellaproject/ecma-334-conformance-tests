/*
Rules: E7-6-ed1-constructor-ref-out-overloads-permitted
Authority: ECMA-334 1st ed 10.6
Version: ISO-1
Expected: run
Stdout: OK 0
Version-Witness: tests/E7-6-ed1-constructor-ref-out-overloads-permitted/constructor-class-witness.cs.part
Mutate: out short result
Into: ref short result
*/
// ECMA-334 1st ed 10.6, p. 79 (PDF p. 93), lines 3-4. Permit same-type
// instance-constructor overload declarations distinguished by reference versus output
// parameter mode in a class or struct.

class Gauge
{
    public Gauge(ref short input) { input = 13; }
    public Gauge(out short result) { result = 27; }
}

class DeclarationEntry
{
    public static int Main()
    {
        System.Console.WriteLine("OK 0");
        return 0;
    }
}
