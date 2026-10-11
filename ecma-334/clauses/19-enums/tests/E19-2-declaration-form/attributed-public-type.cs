/*
Rules: E19-2-declaration-form; E19-2-declared-components; E19-2-body-form; E19-2-body-trailing-comma; E19-1-named-constants
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: enum Signal : byte
Into: struct Signal : byte
*/
using System;
[Flags] public enum Signal : byte { Start = 1, Stop = 4, };
enum Empty { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const Signal named = Signal.Stop;
        Check((byte)named == 4, "declared-name-and-members");
        Check((int)default(Empty) == 0, "empty-body-permitted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
