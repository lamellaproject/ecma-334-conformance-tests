/*
Rules: E10-3-2-decimal-overflow
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: decimal high=decimal.MaxValue;
Into: decimal high=default(decimal);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal high=decimal.MaxValue;
        try { int x=unchecked((int)high); Check(false, "E10-3-2-decimal-overflow-pilot-001-check-01"); } catch (OverflowException) { Check(true, "E10-3-2-decimal-overflow-pilot-001-check-01"); } catch (Exception error) { Check(false, "E10-3-2-decimal-overflow-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
