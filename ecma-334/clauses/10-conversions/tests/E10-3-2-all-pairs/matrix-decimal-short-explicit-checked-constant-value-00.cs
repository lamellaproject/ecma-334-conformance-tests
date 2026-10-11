/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 7
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            const decimal input = 0m;
            short result = checked((short)input);
            Check(result==(short)(0), "decimal-short-explicit-checked-constant-2");
        }
        {
            const decimal input = 1m;
            short result = checked((short)input);
            Check(result==(short)(1), "decimal-short-explicit-checked-constant-3");
        }
        {
            const decimal input = 0.1m;
            short result = checked((short)input);
            Check(result==(short)(0), "decimal-short-explicit-checked-constant-5");
        }
        {
            const decimal input = 1E-28m;
            short result = checked((short)input);
            Check(result==(short)(0), "decimal-short-explicit-checked-constant-7");
        }
        {
            const decimal input = 32766m;
            short result = checked((short)input);
            Check(result==(short)(32766), "decimal-short-explicit-checked-constant-12");
        }
        {
            const decimal input = 32767m;
            short result = checked((short)input);
            Check(result==(short)(32767), "decimal-short-explicit-checked-constant-13");
        }
        {
            const decimal input = 32767.75m;
            short result = checked((short)input);
            Check(result==(short)(32767), "decimal-short-explicit-checked-constant-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
