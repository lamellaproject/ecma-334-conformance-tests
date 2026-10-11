/*
Rules: E9-7-2-2-ref-local-initializer-context
Authority: ECMA-334 7th ed 9.7.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ref int alias = ref argument;
Into: ref int alias = ref local;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Relay(ref int argument)
    {
        int local = 56;
        ref int alias = ref argument;
        return ref alias;
    }
    static void Main()
    {
        int cell = 5;
        Relay(ref cell) = 60;
        Check(cell == 60, "local-alias-retains-initializer-caller-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
