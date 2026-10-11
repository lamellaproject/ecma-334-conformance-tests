/*
Rules: E10-3-2-all-pairs; E10-3-2-double
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
            double input = 0.0d;
            decimal result = unchecked((decimal)input);
            Check(result==0m, "double-decimal-explicit-unchecked-variable-2");
        }
        {
            double input = -0.0d;
            decimal result = unchecked((decimal)input);
            Check(result==-0m, "double-decimal-explicit-unchecked-variable-3");
        }
        {
            double input = 1.0d;
            decimal result = unchecked((decimal)input);
            Check(result==1m, "double-decimal-explicit-unchecked-variable-4");
        }
        {
            double input = -1.0d;
            decimal result = unchecked((decimal)input);
            Check(result==-1m, "double-decimal-explicit-unchecked-variable-5");
        }
        {
            double input = 0.75d;
            decimal result = unchecked((decimal)input);
            Check(result==0.75m, "double-decimal-explicit-unchecked-variable-6");
        }
        {
            double input = -0.75d;
            decimal result = unchecked((decimal)input);
            Check(result==-0.75m, "double-decimal-explicit-unchecked-variable-7");
        }
        {
            double input = 1.0000000000000001e-30d;
            decimal result = unchecked((decimal)input);
            Check(result==0m, "double-decimal-explicit-unchecked-variable-11");
        }
        {
            double input = -1.0000000000000001e-30d;
            decimal result = unchecked((decimal)input);
            Check(result==-0m, "double-decimal-explicit-unchecked-variable-12");
        }
        {
            double input = 0.10000000000000001d;
            decimal result = unchecked((decimal)input);
            Check(result==0.1000000000000000055511151231m, "double-decimal-explicit-unchecked-variable-13");
        }
        {
            double input = -0.10000000000000001d;
            decimal result = unchecked((decimal)input);
            Check(result==-0.1000000000000000055511151231m, "double-decimal-explicit-unchecked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
