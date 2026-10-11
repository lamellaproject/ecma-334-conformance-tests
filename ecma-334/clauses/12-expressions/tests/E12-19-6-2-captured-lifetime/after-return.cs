/*
Rules: E12-19-6-2-captured-lifetime; E12-19-6-2-capture-definition; E12-19-6-1-outer-variable-definition; E12-19-3-outer-variable-access
Authority: ECMA-334 7th ed 12.19.6.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: local += parameter; values[0]++; return local + values[0];
Into: return parameter + values[0];
*/
using System;
delegate int Result();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Result Make(int parameter, params int[] values)
    {
        int local = 11;
        Result function = () => { local += parameter; values[0]++; return local + values[0]; };
        parameter = 7;
        return function;
    }
    static void Main()
    {
        int[] values = { 3 };
        Result function = Make(5, values);
        Check(function() == 22, "local-and-value-parameter-survive-return");
        Check(values[0] == 4, "parameter-array-is-shared-with-caller");
        Check(function() == 30, "captured-instances-persist-between-invocations");
        Check(values[0] == 5, "array-capture-is-updated-again");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
