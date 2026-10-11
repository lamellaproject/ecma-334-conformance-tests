/*
Rules: E12-2-1-throw-conversion
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw marker
Into: 42
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select(bool flag, Exception marker) { return flag ? 9 : throw marker; }
    static void Main()
    {
        Exception marker = new Exception(); bool caught = false;
        Check(Select(true, marker) == 9, "throw-unselected");
        try { Select(false, marker); }
        catch (Exception error) { caught = error == marker; }
        Check(caught, "throw-conversion-and-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
