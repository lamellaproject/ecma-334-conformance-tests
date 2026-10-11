/*
Rules: E17-6-runtime-store-check
Authority: ECMA-334 7th ed 17.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: new string[] { "kept" }
Into: new object[] { "kept" }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] values = new string[] { "kept" };
        bool rejected = false;
        try { values[0] = new object(); }
        catch (ArrayTypeMismatchException) { rejected = true; }
        catch (Exception) { }
        Check(rejected, "actual-element-type-enforced");
        Check((string)values[0] == "kept", "failed-store-keeps-value");
        values[0] = "valid";
        Check((string)values[0] == "valid", "compatible-store");
        values[0] = null;
        Check(values[0] == null, "null-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
