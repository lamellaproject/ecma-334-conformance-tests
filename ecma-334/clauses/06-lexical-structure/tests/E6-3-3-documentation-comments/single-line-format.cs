/*
Rules: E6-3-3-documentation-comments
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: /// <summary>
Into: <summary>
*/
using System;
/// <summary>Independently authored lexical witness.</summary>
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
