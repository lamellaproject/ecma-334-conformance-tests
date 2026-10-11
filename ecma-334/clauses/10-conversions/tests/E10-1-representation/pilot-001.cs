/*
Rules: E10-1-representation; E10-1-type-wide; E10-2-1-contexts; E10-2-1-predefined-safe; E10-2-3-int; E10-2-3-exact; E10-3-1-includes-implicit
Authority: ECMA-334 7th ed 10.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: long assigned = raw;
Into: long assigned = 0;
*/
using System;
using static Bridge;

static class Bridge { public static long Accept(int x) { return x + 1L; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int raw = Environment.ExitCode + 73;
        long assigned = raw;
        long argument = Accept(raw);
        long cast = (long)raw;
        Check(assigned == 73 && argument == 74 && cast == 73, "E10-1-representation-pilot-001-check-01");
        Check(((object)assigned).GetType() == typeof(long), "E10-1-representation-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
