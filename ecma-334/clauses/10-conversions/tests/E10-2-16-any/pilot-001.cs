/*
Rules: E10-2-16-any; E10-2-16-value; E9-3-value-default; E9-3-reference-default; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.16
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int number=default;
Into: int number=1;
*/
using System;

struct State { public int Number; public string Text; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int number=default; string text=default; int? nullable=default; State state=default;
        Check(number==0 && text==null && !nullable.HasValue && state.Number==0 && state.Text==null, "E10-2-16-any-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
