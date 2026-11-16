/*
Rules: E10-3-2-float-decimal-round; E10-3-2-float-decimal-small; E10-3-2-float-decimal-large; E10-3-2-float-decimal-nan
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"target_requires":["decimal-96-scale-28"]}
Mutate: decimal d=(decimal)x;
Into: decimal d=0m;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double fraction=0.1d, tiny=1e-300, huge=1e100, nan=double.NaN;
        decimal rounded=(decimal)fraction, zero=(decimal)tiny;
        Check(rounded==0.1000000000000000055511151231m && zero==0m, "E10-3-2-float-decimal-round-pilot-001-check-01");
        int exceptions=0;
        foreach(double x in new double[]{huge,double.PositiveInfinity,double.NegativeInfinity,nan}) {
            try { decimal d=(decimal)x; Check(false, "E10-3-2-float-decimal-round-pilot-001-check-02"); } catch(OverflowException) { exceptions++; } catch (Exception error) { Check(false, "E10-3-2-float-decimal-round-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        }
        Check(exceptions==4, "E10-3-2-float-decimal-round-pilot-001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
