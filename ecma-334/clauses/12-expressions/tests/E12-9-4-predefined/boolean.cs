/*
Rules: E12-9-4-predefined; E12-9-4-true; E12-9-4-false; E12-9-4-lifted; E12-9-1-form-not
Authority: ECMA-334 7th ed 12.9.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: !yes
Into: yes
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool yes = true, no = false; bool? present = true, missing = null;
        Check(!yes == false, "true"); Check(!no == true, "false");
        Check(!present == false, "lifted-value"); Check(!missing == null, "lifted-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
