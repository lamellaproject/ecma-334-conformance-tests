/*
Rules: E12-23-predefined-binary; E12-23-compile-time-evaluation; E12-23-constant-evaluation-semantics
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const bool equal = First == Second;
Into: const bool equal = First != Second;
*/
// ECMA-334 5th ed 12.20, p. 216 (PDF p. 238).
using System;
class Program
{
    const object First = null;
    const object Second = null;
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        const bool equal = First == Second;
        const bool different = First != Second;
        Check(equal, "constant-null-object-equality");
        Check(!different, "constant-null-object-inequality");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
