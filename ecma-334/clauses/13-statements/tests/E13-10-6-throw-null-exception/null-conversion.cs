/*
Rules: E13-10-6-throw-null-exception
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/null-conversion-70d96c9247.cs.part
Mutate: throw new Source();
Into: throw new Exception();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int converted;
    struct Source
    {
        public static implicit operator Exception(Source value) { converted++; return null; }
    }
    static void Main()
    {
        bool rightType = false;
        try { throw new Source(); }
        catch (NullReferenceException) { rightType = true; }
        catch (Exception) { }
        Check(rightType && converted == 1, "null-after-user-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
