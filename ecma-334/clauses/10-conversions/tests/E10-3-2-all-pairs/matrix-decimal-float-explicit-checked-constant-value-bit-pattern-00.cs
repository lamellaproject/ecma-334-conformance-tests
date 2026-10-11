/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 8
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
            const decimal input = 79228162514264337593543950335m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1870659584U, "decimal-float-explicit-checked-constant-1");
        }
        {
            const decimal input = 0m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "decimal-float-explicit-checked-constant-2");
        }
        {
            const decimal input = 1m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "decimal-float-explicit-checked-constant-3");
        }
        {
            const decimal input = 0.1m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1036831949U, "decimal-float-explicit-checked-constant-5");
        }
        {
            const decimal input = 1E-28m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==285050806U, "decimal-float-explicit-checked-constant-7");
        }
        {
            const decimal input = 16777215m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "decimal-float-explicit-checked-constant-9");
        }
        {
            const decimal input = 16777216m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "decimal-float-explicit-checked-constant-10");
        }
        {
            const decimal input = 16777217m;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "decimal-float-explicit-checked-constant-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
