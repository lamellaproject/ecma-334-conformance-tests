/*
Rules: E9-7-2-3-reference-parameter-context; E9-7-2-3-input-parameter-context; E9-7-2-3-input-readonly-ref-return
Authority: ECMA-334 7th ed 9.7.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return ref input;
Into: return ref backup;
*/
using System;
class Program
{
    static int checks, failures, backup = 3;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Reference(ref int parameter) { return ref parameter; }
    static ref readonly int Input(in int input) { return ref input; }
    static void Main()
    {
        int cell = 7;
        Reference(ref cell) = 72;
        Check(cell == 72, "ref-parameter-caller-context");
        ref readonly int input = ref Input(in cell);
        cell = 80;
        Check(input == 80, "in-parameter-readonly-caller-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
