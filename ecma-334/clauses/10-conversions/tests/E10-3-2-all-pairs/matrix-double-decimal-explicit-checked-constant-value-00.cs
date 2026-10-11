/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 10
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
            const double input = 0.0d;
            decimal result = checked((decimal)input);
            Check(result==0m, "double-decimal-explicit-checked-constant-2");
        }
        {
            const double input = -0.0d;
            decimal result = checked((decimal)input);
            Check(result==-0m, "double-decimal-explicit-checked-constant-3");
        }
        {
            const double input = 1.0d;
            decimal result = checked((decimal)input);
            Check(result==1m, "double-decimal-explicit-checked-constant-4");
        }
        {
            const double input = -1.0d;
            decimal result = checked((decimal)input);
            Check(result==-1m, "double-decimal-explicit-checked-constant-5");
        }
        {
            const double input = 0.75d;
            decimal result = checked((decimal)input);
            Check(result==0.75m, "double-decimal-explicit-checked-constant-6");
        }
        {
            const double input = -0.75d;
            decimal result = checked((decimal)input);
            Check(result==-0.75m, "double-decimal-explicit-checked-constant-7");
        }
        {
            const double input = 1.0000000000000001e-30d;
            decimal result = checked((decimal)input);
            Check(result==0m, "double-decimal-explicit-checked-constant-11");
        }
        {
            const double input = -1.0000000000000001e-30d;
            decimal result = checked((decimal)input);
            Check(result==-0m, "double-decimal-explicit-checked-constant-12");
        }
        {
            const double input = 0.10000000000000001d;
            decimal result = checked((decimal)input);
            Check(result==0.1000000000000000055511151231m, "double-decimal-explicit-checked-constant-13");
        }
        {
            const double input = -0.10000000000000001d;
            decimal result = checked((decimal)input);
            Check(result==-0.1000000000000000055511151231m, "double-decimal-explicit-checked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
