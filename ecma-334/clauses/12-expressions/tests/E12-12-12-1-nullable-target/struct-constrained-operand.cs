/*
Rules: E12-12-12-1-nullable-target; E12-12-12-1-runtime-check; E12-12-12-1-otherwise-false
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return value is int?;
Into: return value is long?;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Stamp { }
    static bool MatchesValue<T>(T value) where T : struct { return value is int?; }
    static int Main()
    {
        Check(MatchesValue<int>(31), "struct-parameter-matching-target");
        Check(!MatchesValue<long>(31L), "struct-parameter-other-numeric-type");
        Check(!MatchesValue<Stamp>(new Stamp()), "struct-parameter-user-value-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
