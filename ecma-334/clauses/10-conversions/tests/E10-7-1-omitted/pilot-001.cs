/*
Rules: E10-7-1-omitted
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: delegate {Trace.Count++;}
Into: delegate {Trace.Count+=2;}
*/
using System;

static class Trace {public static int Count;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Action<int,string> anonymous=delegate {Trace.Count++;};
        anonymous(61,"seed"); Check(Trace.Count==1, "E10-7-1-omitted-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
