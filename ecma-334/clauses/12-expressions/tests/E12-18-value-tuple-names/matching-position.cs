/*
Rules: E12-18-value-tuple-names; E12-18-value-identity-common-type
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (int kept, int rightName) right = (17, 19);
Into: (int changed, int rightName) right = (17, 19);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool takeLeft = false;
        (int kept, int leftName) left = (11, 13);
        (int kept, int rightName) right = (17, 19);
        var result = takeLeft ? left : right;
        Check(result.kept == 17, "matching-name-is-preserved");
        Check(result.Item2 == 19, "differing-name-keeps-ordinal-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
