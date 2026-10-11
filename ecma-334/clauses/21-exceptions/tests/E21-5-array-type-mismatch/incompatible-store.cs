/*
Rules: E21-5-array-type-mismatch
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new string[1]
Into: new object[1]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] values = new string[1]; bool caught = false;
        try { values[0] = new object(); }
        catch (ArrayTypeMismatchException) { caught = true; }
        catch (Exception) { }
        Check(caught, "incompatible-store-exception");
        Check(values[0] == null, "failed-store-leaves-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
