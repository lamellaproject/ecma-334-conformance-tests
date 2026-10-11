/*
Rules: E10-3-2-float-special-checked; E10-3-2-float-overflow-checked
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int y=checked((int)x);
Into: int y=default(int);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double[] values={double.NaN, double.PositiveInfinity, double.NegativeInfinity, 1e100};
        int count=0;
        foreach(double x in values) { try { int y=checked((int)x); Check(false, "E10-3-2-float-special-checked-pilot-001-check-01"); } catch(OverflowException) { count++; } catch (Exception error) { Check(false, "E10-3-2-float-special-checked-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); } }
        Check(count==4, "E10-3-2-float-special-checked-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
