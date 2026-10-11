/*
Rules: E6-5-7-region-marker; E6-5-7-grammar-pp-region-1; E6-5-7-grammar-pp-region-2; E6-5-7-grammar-pp-start-region-1; E6-5-7-grammar-pp-end-region-1; E6-5-7-region-no-semantics; E6-5-7-region-message-no-semantics; E6-5-7-region-different-messages; E6-5-1-grammar-pp-kind-5
Authority: ECMA-334 7th ed 6.5.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #endregion closure
Into: // removed terminator
*/
using System;
#region beginning: amount = 0;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 19;
        Check(amount == 19, "region-messages-do-not-execute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endregion closure
