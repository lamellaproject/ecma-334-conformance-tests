/*
Rules: E9-4-4-31-anonymous-parameter-state
Authority: ECMA-334 7th ed 9.4.4.31
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: (out int parameter) => { parameter = 73; }
Into: (out int parameter) => { }
*/
using System;
delegate int Reference(ref int parameter);
delegate int Input(in int parameter);
delegate void Output(out int parameter);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<int, int> value = (int parameter) => parameter + 1;
        Reference reference = (ref int parameter) => parameter + 2;
        Input input = (in int parameter) => parameter + 3;
        Output output = (out int parameter) => { parameter = 73; };
        int cell = 15;
        Check(value(cell) == 16, "anonymous-value-parameter-assigned");
        Check(reference(ref cell) == 17, "anonymous-ref-parameter-assigned");
        Check(input(in cell) == 18, "anonymous-input-parameter-assigned");
        output(out cell);
        Check(cell == 73, "anonymous-output-parameter-assigned-at-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
