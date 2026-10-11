/*
Rules: E13-9-4-for-initializer-variable-scope; E13-9-4-form-for-variable-initializer; E13-9-4-for-initializer-order
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: stride = index + 1
Into: stride = Program.index + 1
*/
using System;
class Program
{
    static int checks, failures, index = 9, stride = 7;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int trace = 9;
        for (int index = 0, stride = index + 1; index < 3; index += stride)
        {
            trace = trace * 10 + index;
        }
        Check(trace == 9012, "initializer-variables-visible-in-all-for-components");
        Check(index == 9 && stride == 7, "for-variable-scope-ends-with-statement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
