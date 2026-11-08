/*
Rules: E12-13-5-ed3-nullable-boolean-condition
Authority: ECMA-334 3rd ed 14.10.4
Version: ISO-2
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E12-13-5-ed3-nullable-boolean-condition/conditional-condition.cs.part
Mutate: return gate ? 11 : 29;
Into: return gate != true ? 11 : 29;
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
    static int Select(bool? gate) { return gate ? 11 : 29; }
    static int Main()
    {
        Check(Select(true) == 11, "true-condition");
        Check(Select(false) == 29, "false-condition");
        Check(Select(null) == 29, "null-condition");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
