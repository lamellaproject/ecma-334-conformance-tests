/*
Rules: E10-3-3-to-enum; E10-3-3-from-enum; E10-3-3-enum-enum; E10-3-3-underlying; E10-3-1-categories
Authority: ECMA-334 7th ed 10.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: First a=unchecked((First)input);
Into: First a=default(First);
*/
using System;

enum First : byte { A=0 } enum Second : long { B=0 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input=65597; First a=unchecked((First)input); Second b=(Second)a;
        decimal number=(decimal)b;
        Check((byte)a==61 && (long)b==61 && number==61, "E10-3-3-to-enum-pilot-001-check-01");
        try { First fail=checked((First)input); Check(false, "E10-3-3-to-enum-pilot-001-check-02"); } catch (OverflowException) { Check(true, "E10-3-3-to-enum-pilot-001-check-02"); } catch (Exception error) { Check(false, "E10-3-3-to-enum-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
