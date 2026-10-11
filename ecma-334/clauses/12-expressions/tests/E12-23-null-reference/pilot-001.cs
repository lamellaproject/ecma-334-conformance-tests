/*
Rules: E12-23-null-reference
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: const string Nothing=null;
Into: const string Nothing="present";
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const string Nothing=null; const object Converted=Nothing;
        Check(Converted==null, "E12-23-null-reference-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
