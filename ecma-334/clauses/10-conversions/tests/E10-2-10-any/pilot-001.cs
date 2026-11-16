/*
Rules: E10-2-10-any; E10-2-10-lookup; E10-2-10-failure; E10-2-10-object-first; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: long widened=source;
Into: long widened=0;
*/
using System;


class Program
{
    static int checks, failures;
    static int input;
    static int Next() { return ++input; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic source=Next()+60; long widened=source; object staticSource=(object)source;
        Check(widened==61 && (int)staticSource==61, "E10-2-10-any-pilot-001-check-01");
        try { byte narrow=source; Check(false, "E10-2-10-any-pilot-001-check-02"); } catch (Exception) { Check(true, "E10-2-10-any-pilot-001-check-02"); }
        try { long unbox=(long)staticSource; Check(false, "E10-2-10-any-pilot-001-check-03"); } catch (InvalidCastException) { Check(true, "E10-2-10-any-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-2-10-any-unexpected-exception-2"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
