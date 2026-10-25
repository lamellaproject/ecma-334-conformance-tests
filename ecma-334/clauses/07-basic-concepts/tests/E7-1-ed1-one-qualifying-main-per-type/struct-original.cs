/*
Rules: E7-1-ed1-one-qualifying-main-per-type
Authority: ECMA-334 1st ed 10.1
Version: ISO-1
Expected: reject
Fixture: {"program":{"entry_point":"CaseApplication"}}
Version-Witness: tests/E7-1-ed1-one-qualifying-main-per-type/struct-original.witness.cs.part
Mutate: static int Main(string[] channels)
Into: static int Spare(string[] channels)
*/
// ECMA-334 1st ed 10.1, p. 69 (PDF p. 83), lines 24-25. Within an application program,
// refuse a class or struct containing more than one method called Main whose definition
// qualifies as an application entry point, including when the actual entry point is
// selected in another type.
struct CaseCarrier
{
    static void Main()
    {
        System.Console.WriteLine("OK 0");
    }

    static int Main(string[] channels)
    {
        return 0;
    }
}

class CaseApplication
{
    static int Main()
    {
        System.Console.WriteLine("OK 0");
        return 0;
    }
}
