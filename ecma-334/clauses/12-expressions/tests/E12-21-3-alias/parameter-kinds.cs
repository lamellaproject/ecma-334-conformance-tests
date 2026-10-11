/*
Rules: E12-21-3-alias; E12-21-3-writeable-right-readonly-left
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: input = ref destination
Into: input = ref fallback
*/
using System;
class Program
{
    static int fallback = 2;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void RefMove(ref int parameter, ref int destination) { parameter = ref destination; parameter = 30; }
    static void OutMove(out int parameter, ref int destination) { parameter = 5; parameter = ref destination; parameter = 31; }
    static int InMove(in int input, ref int destination) { input = ref destination; return input; }
    static void Main()
    {
        int original = 7, destination = 9;
        RefMove(ref original, ref destination);
        Check(original == 7 && destination == 30, "ref-parameter-rebound");
        OutMove(out original, ref destination);
        Check(original == 5 && destination == 31, "assigned-out-parameter-rebound");
        int read = InMove(in original, ref destination);
        Check(read == 31 && original == 5, "in-parameter-rebound-read-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
