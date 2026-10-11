/*
Rules: E8-3-12-nullable-shorthand; E8-3-12-value-to-nullable-conversion; E8-3-12-nullable-value-set; E8-3-1-nullable-correspondence
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int? value = 28;
Into: int? value = 29;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Take(ref int? value) { }
    static void Main()
    {
        int? value = 28; Nullable<int> alias = value;
        Take(ref alias);
        Check(alias.Value == 28, "nullable-interchangeable-forms");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
