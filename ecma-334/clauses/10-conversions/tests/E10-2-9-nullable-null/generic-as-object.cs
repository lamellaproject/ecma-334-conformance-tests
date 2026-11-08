/*
Rules: E10-2-9-nullable-null; E10-2-9-nullable-value; E12-12-13-open-type; E12-12-13-static-result
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Box<int?>(null)
Into: Box<int?>(0)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static object Box<T>(T value) { return value as object; }
    static int Main()
    {
        object absent = Box<int?>(null);
        Check(absent == null, "generic-nullable-as-null");
        object present = Box<int?>(29);
        Check(present is int && (int)present == 29, "generic-nullable-as-underlying-box");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
