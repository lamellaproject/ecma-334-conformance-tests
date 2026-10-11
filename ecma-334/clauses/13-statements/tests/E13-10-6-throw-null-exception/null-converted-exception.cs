/*
Rules: E13-10-6-throw-null-exception
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw (Exception)null;
Into: throw new Exception();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool rightType = false;
        try { throw (Exception)null; }
        catch (NullReferenceException) { rightType = true; }
        catch (Exception) { }
        Check(rightType, "null-throw-produces-null-reference-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
