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
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic source=61; long widened=source; object staticSource=(object)source;
        Check(widened==61 && staticSource.GetType()==typeof(int), "E10-2-10-any-pilot-001-check-01");
        try { byte narrow=source; Check(false, "E10-2-10-any-pilot-001-check-02"); } catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { Check(true, "E10-2-10-any-pilot-001-check-02"); } catch (Exception error) { Check(false, "E10-2-10-any-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        try { long unbox=(long)staticSource; Check(false, "E10-2-10-any-pilot-001-check-03"); } catch (InvalidCastException) { Check(true, "E10-2-10-any-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-2-10-any-unexpected-exception-2"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
