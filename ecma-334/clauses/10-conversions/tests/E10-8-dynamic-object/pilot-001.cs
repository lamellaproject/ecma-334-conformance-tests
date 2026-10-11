/*
Rules: E10-8-dynamic-object
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Func<dynamic,int> converted=Bridge.Read;
Into: Func<dynamic,int> converted=default(Func<dynamic,int>);
*/
using System;

static class Bridge {public static int Read(object x){return 61;} public static int Read(string x){return 82;} }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<dynamic,int> converted=Bridge.Read;
        Check(converted("seed")==61, "E10-8-dynamic-object-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
