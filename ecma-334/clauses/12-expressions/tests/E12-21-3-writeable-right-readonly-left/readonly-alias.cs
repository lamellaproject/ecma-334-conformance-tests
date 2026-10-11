/*
Rules: E12-21-3-writeable-right-readonly-left; E12-21-3-alias
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: alias = ref second
Into: alias = ref first
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = 6, second = 13;
        ref readonly int alias = ref first;
        alias = ref second;
        Check(alias == 13 && first == 6, "read-only-left-accepts-writeable-right");
        second = 27;
        Check(alias == 27, "read-only-alias-observes-new-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
