/*
Rules: E12-21-3-result-reference; E12-21-3-result-type; E12-21-3-result-writeability; E12-21-3-alias; E12-21-1-ref-assignment; E12-21-1-ref-form; E12-21-1-ref-name; E12-21-1-ref-referent
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (alias = ref next)
Into: (alias = ref first)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = 4, next = 11;
        ref int alias = ref first;
        ref int result = ref (alias = ref next);
        result = 29;
        Check(next == 29 && first == 4, "writeable-result-references-new-location");
        alias = 37;
        Check(result == 37 && next == 37, "left-and-result-alias-same-variable");
        next = 41;
        Check(result == 41 && alias == 41, "reassignment-copies-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
