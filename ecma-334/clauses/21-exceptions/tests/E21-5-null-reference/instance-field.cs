/*
Rules: E21-5-null-reference
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Receiver source = null
Into: Receiver source = new Receiver()
*/
using System;
class Receiver { public int Value = 1; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver source = null; bool caught = false;
        try { int result = source.Value; }
        catch (NullReferenceException) { caught = true; }
        catch (Exception) { }
        Check(caught, "null-instance-field-access-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
