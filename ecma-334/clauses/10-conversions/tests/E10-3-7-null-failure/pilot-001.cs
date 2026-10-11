/*
Rules: E10-3-7-null-failure; E10-3-7-type-failure; E10-3-7-nullable-type-failure
Authority: ECMA-334 7th ed 10.3.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int x=(int)nothing;
Into: int x=default(int);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object nothing=null, number=61;
        try { int x=(int)nothing; Check(false, "E10-3-7-null-failure-pilot-001-check-01"); } catch (NullReferenceException) { Check(true, "E10-3-7-null-failure-pilot-001-check-01"); } catch (Exception error) { Check(false, "E10-3-7-null-failure-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        try { long x=(long)number; Check(false, "E10-3-7-null-failure-pilot-001-check-02"); } catch (InvalidCastException) { Check(true, "E10-3-7-null-failure-pilot-001-check-02"); } catch (Exception error) { Check(false, "E10-3-7-null-failure-unexpected-exception-2"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        try { long? x=(long?)number; Check(false, "E10-3-7-null-failure-pilot-001-check-03"); } catch (InvalidCastException) { Check(true, "E10-3-7-null-failure-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-3-7-null-failure-unexpected-exception-3"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
