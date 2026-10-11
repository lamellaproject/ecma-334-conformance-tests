/*
Rules: E10-3-2-float-special-unspecified; E10-3-2-float-unchecked-success
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unchecked((int)input)
Into: checked((int)input)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double input = double.NaN;
        bool completed = false;
        try
        {
            // Every destination value is allowed; this checks only that the conversion completes.
            int result = unchecked((int)input);
            completed = true;
        }
        catch (Exception)
        {
        }
        Check(completed, "nan-int-domain/must-succeed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
