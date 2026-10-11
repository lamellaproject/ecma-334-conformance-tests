/*
Rules: E10-2-9-enum; E10-3-7-enum
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Enum boxed=value;
Into: Enum boxed=default(Enum);
*/
using System;

enum Label:byte {Seed=61}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Label value=Label.Seed; Enum boxed=value;
        Label restored=(Label)boxed;
        Check(restored==Label.Seed && boxed.GetType()==typeof(Label), "E10-2-9-enum-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
