/*
Rules: E10-3-2-all-pairs; E10-3-2-float; E12-23-numeric
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
            const float input = 0.0f;
            decimal result = checked((decimal)input);
            Check(result==0m, "float-decimal-explicit-checked-constant-2");
        }
        {
            const float input = -0.0f;
            decimal result = checked((decimal)input);
            Check(result==-0m, "float-decimal-explicit-checked-constant-3");
        }
        {
            const float input = 1.0f;
            decimal result = checked((decimal)input);
            Check(result==1m, "float-decimal-explicit-checked-constant-4");
        }
        {
            const float input = -1.0f;
            decimal result = checked((decimal)input);
            Check(result==-1m, "float-decimal-explicit-checked-constant-5");
        }
        {
            const float input = 0.75f;
            decimal result = checked((decimal)input);
            Check(result==0.75m, "float-decimal-explicit-checked-constant-6");
        }
        {
            const float input = -0.75f;
            decimal result = checked((decimal)input);
            Check(result==-0.75m, "float-decimal-explicit-checked-constant-7");
        }
        {
            const float input = 1e-30f;
            decimal result = checked((decimal)input);
            Check(result==0m, "float-decimal-explicit-checked-constant-11");
        }
        {
            const float input = -1e-30f;
            decimal result = checked((decimal)input);
            Check(result==-0m, "float-decimal-explicit-checked-constant-12");
        }
        {
            const float input = 0.100000001f;
            decimal result = checked((decimal)input);
            Check(result==0.100000001490116119384765625m, "float-decimal-explicit-checked-constant-13");
        }
        {
            const float input = -0.100000001f;
            decimal result = checked((decimal)input);
            Check(result==-0.100000001490116119384765625m, "float-decimal-explicit-checked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
