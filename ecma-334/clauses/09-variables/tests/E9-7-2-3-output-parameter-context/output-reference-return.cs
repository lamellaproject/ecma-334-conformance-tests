/*
Rules: E9-7-2-3-output-parameter-context
Authority: ECMA-334 7th ed 9.7.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/output-reference-return-aa1176aaf9.cs.part
Mutate: return ref output;
Into: return ref backup;
*/
using System;
class Program
{
    static int checks, failures, backup = 3;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Select(out int output) { output = 68; return ref output; }
    static void Main()
    {
        int cell;
        ref int alias = ref Select(out cell);
        alias = 72;
        Check(cell == 72, "out-parameter-has-caller-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
