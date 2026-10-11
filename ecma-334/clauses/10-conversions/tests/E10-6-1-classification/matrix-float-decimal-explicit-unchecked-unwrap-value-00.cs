/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            float? input = 0.0f;
            decimal result = unchecked((decimal)input);
            Check(result==0m, "nullable-float-decimal-explicit-unchecked-unwrap-2");
        }
        {
            float? input = -0.0f;
            decimal result = unchecked((decimal)input);
            Check(result==-0m, "nullable-float-decimal-explicit-unchecked-unwrap-3");
        }
        {
            float? input = 1.0f;
            decimal result = unchecked((decimal)input);
            Check(result==1m, "nullable-float-decimal-explicit-unchecked-unwrap-4");
        }
        {
            float? input = -1.0f;
            decimal result = unchecked((decimal)input);
            Check(result==-1m, "nullable-float-decimal-explicit-unchecked-unwrap-5");
        }
        {
            float? input = 0.75f;
            decimal result = unchecked((decimal)input);
            Check(result==0.75m, "nullable-float-decimal-explicit-unchecked-unwrap-6");
        }
        {
            float? input = -0.75f;
            decimal result = unchecked((decimal)input);
            Check(result==-0.75m, "nullable-float-decimal-explicit-unchecked-unwrap-7");
        }
        {
            float? input = 1e-30f;
            decimal result = unchecked((decimal)input);
            Check(result==0m, "nullable-float-decimal-explicit-unchecked-unwrap-11");
        }
        {
            float? input = -1e-30f;
            decimal result = unchecked((decimal)input);
            Check(result==-0m, "nullable-float-decimal-explicit-unchecked-unwrap-12");
        }
        {
            float? input = 0.100000001f;
            decimal result = unchecked((decimal)input);
            Check(result==0.100000001490116119384765625m, "nullable-float-decimal-explicit-unchecked-unwrap-13");
        }
        {
            float? input = -0.100000001f;
            decimal result = unchecked((decimal)input);
            Check(result==-0.100000001490116119384765625m, "nullable-float-decimal-explicit-unchecked-unwrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
