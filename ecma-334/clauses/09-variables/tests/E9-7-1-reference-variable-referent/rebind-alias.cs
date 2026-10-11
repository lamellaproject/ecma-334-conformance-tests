/*
Rules: E9-7-1-reference-variable-referent; E9-7-1-reference-local-declaration; E9-7-1-reference-variable-storage; E9-7-1-reference-variable-read; E9-7-1-reference-variable-assignment; E9-7-1-reference-variable-reassignment
Authority: ECMA-334 7th ed 9.7.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: alias = ref second;
Into: alias = second;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = 5, second = 9;
        ref int alias = ref first;
        first = 13;
        Check(alias == 13, "alias-stores-location-rather-than-initial-value");
        alias = 17;
        Check(first == 17 && second == 9, "ordinary-assignment-writes-referent");
        alias = ref second;
        alias = 21;
        Check(first == 17 && second == 21, "ref-assignment-changes-referent");
        second = 25;
        Check(alias == 25, "read-after-rebinding-fetches-current-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
