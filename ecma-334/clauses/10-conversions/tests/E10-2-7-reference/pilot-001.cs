/*
Rules: E10-2-7-reference; E10-2-7-nullable; E10-2-7-null-result; E10-2-8-null; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: string text=null;
Into: string text="present";
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text=null; int? value=null; Action action=null; int[] array=null;
        Check(text==null && !value.HasValue && action==null && array==null, "E10-2-7-reference-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
