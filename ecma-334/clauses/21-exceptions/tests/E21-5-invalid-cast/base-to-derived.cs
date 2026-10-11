/*
Rules: E21-5-invalid-cast
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object source = new object()
Into: object source = "valid string"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = new object(); bool caught = false;
        try { string result = (string)source; }
        catch (InvalidCastException) { caught = true; }
        catch (Exception) { }
        Check(caught, "failed-base-to-derived-cast-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
