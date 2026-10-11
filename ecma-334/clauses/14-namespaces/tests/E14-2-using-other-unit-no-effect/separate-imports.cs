/*
Rules: E14-2-using-other-unit-no-effect; E14-2-using-unit-scope
Authority: ECMA-334 7th ed 14.2
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"units":[{"source":"self"},{"source":"tests/E14-2-using-other-unit-no-effect/second.cs.part"}]}}
Mutate: using ForeignFirst;
Into: using ForeignSecond;
*/
using System;
using ForeignFirst;
namespace ForeignFirst { class Beacon { public const int Code = 29; } }
namespace ForeignSecond { class Beacon { public const int Code = 31; } }
namespace First { class Reader { public static int Read() { return Beacon.Code; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(First.Reader.Read() == 29, "first-unit-import");
        Check(Second.Reader.Read() == 31, "second-unit-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
