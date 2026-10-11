/*
Rules: E17-3-default-elements
Authority: ECMA-334 7th ed 17.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new object[2]
Into: new object[] { new object(), null }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] values = new object[2];
        Check(values[0] == null, "first-null");
        Check(values[1] == null, "last-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
