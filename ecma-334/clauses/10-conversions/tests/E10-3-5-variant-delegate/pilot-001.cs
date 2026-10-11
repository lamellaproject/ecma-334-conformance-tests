/*
Rules: E10-3-5-variant-delegate
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Action<Second> target=(Action<Second>)source;
Into: Action<Second> target=default(Action<Second>);
*/
using System;

class First {} class Second {} static class Trace {public static int Count;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Action<First> source=x=>Trace.Count++;
        try { Action<Second> target=(Action<Second>)source; Check(false, "E10-3-5-variant-delegate-pilot-001-check-01"); } catch (InvalidCastException) { Check(true, "E10-3-5-variant-delegate-pilot-001-check-01"); } catch (Exception error) { Check(false, "E10-3-5-variant-delegate-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        Check(Trace.Count==0, "E10-3-5-variant-delegate-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
