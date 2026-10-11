/*
Rules: E10-3-2-float-unchecked-success; E10-3-2-float-special-unspecified; E10-3-2-float-range-unspecified
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unchecked((int)x)
Into: checked((int)x)
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double[] values={double.NaN, double.PositiveInfinity, double.NegativeInfinity, 1e100, -1e100};
        int count=0;
        // Every destination value is allowed; this checks only that all conversions complete.
        foreach(double x in values)
        {
            try { int y=unchecked((int)x); count++; }
            catch (Exception error)
            {
                Check(false, "float-unchecked-success/completion");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        Check(count==5, "E10-3-2-float-unchecked-success-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
