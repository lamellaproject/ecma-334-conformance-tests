/*
Rules: E10-8-value-box
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: value.Number=82;
Into: value.Number=83;
*/
using System;

struct Counter {public int Number;public int Next(){return ++Number;} }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value=new Counter {Number=61}; Func<int> converted=value.Next;
        value.Number=82;
        Check(converted()==62 && converted()==63 && value.Number==82 && converted.Target.GetType()==typeof(Counter), "E10-8-value-box-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
