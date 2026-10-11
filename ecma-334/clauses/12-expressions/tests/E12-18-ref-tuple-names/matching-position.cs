/*
Rules: E12-18-ref-tuple-names; E12-18-ref-result-reference; E12-18-ref-result-type; E12-18-ref-result-writeability
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (int kept, int rightName) right = (29, 31);
Into: (int changed, int rightName) right = (29, 31);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool takeLeft = true;
        (int kept, int leftName) left = (19, 23);
        (int kept, int rightName) right = (29, 31);
        ref var result = ref (takeLeft ? ref left : ref right);
        Check(result.kept == 19, "ref-matching-name-is-preserved");
        result.kept = 37;
        Check(left.kept == 37 && right.kept == 29, "named-field-writes-selected-storage");
        result.Item2 = 41;
        Check(left.leftName == 41 && right.rightName == 31, "ordinal-field-writes-selected-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
