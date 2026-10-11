/*
Rules: E17-6-implicit-covariance; E17-6-covariant-instance
Authority: ECMA-334 7th ed 17.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: object[] erased = values
Into: object[] erased = new object[2]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] values = new string[2];
        object[] erased = values;
        Check(erased == values, "covariance-keeps-identity");
        Check(erased is string[], "actual-array-type");
        erased[1] = "stored";
        Check(values[1] == "stored", "permitted-derived-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
