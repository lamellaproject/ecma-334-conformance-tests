/*
Rules: E12-13-5-ed3-nullable-boolean-condition
Authority: ECMA-334 3rd ed 14.10.4
Version: ISO-2
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E12-13-5-ed3-nullable-boolean-condition/do-condition.cs.part
Mutate: while (gate);
Into: while (gate != true);
*/
// ECMA-334 3rd ed 14.10.4, p. 213 (PDF p. 233).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Select(bool? gate) { int count = 0; do { count++; if (count == 2) break; } while (gate); return count; }
    static int Main()
    {
        Check(Select(true) == 2, "true-condition");
        Check(Select(false) == 1, "false-condition");
        Check(Select(null) == 1, "null-condition");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
