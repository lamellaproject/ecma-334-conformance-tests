/*
Rules: E12-9-7-result-value
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int converted=(int)source;
Into: int converted=default(int);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int source=61; int converted=(int)source;
        Check(converted==61, "cast-result-value/before-reassignment");
        converted=82;
        Check(source==61 && converted==82, "E12-9-7-result-value-pilot-002-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
