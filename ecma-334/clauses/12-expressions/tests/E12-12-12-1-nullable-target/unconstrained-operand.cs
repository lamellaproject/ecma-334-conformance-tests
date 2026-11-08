/*
Rules: E12-12-12-1-nullable-target; E12-12-12-1-runtime-check; E12-12-12-1-null-value-false
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: run
Stdout: OK 6
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
    static bool Matches<T>(T value) { return value is int?; }
    static int Main()
    {
        Check(Matches<int>(29), "open-int-to-nullable-target");
        Check(Matches<int?>(29), "open-present-nullable-target");
        Check(!Matches<int?>(null), "open-nullable-null-target");
        Check(Matches<object>(29), "open-boxed-underlying-target");
        Check(!Matches<string>("cedar"), "open-incompatible-target");
        int? empty = null;
        Check(!(empty is int?), "closed-nullable-identity-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
