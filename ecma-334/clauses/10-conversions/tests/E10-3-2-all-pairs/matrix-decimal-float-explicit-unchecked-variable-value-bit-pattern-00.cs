/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 15
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
            decimal input = -79228162514264337593543950335m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==4018143232U, "decimal-float-explicit-unchecked-variable-0");
        }
        {
            decimal input = 79228162514264337593543950335m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1870659584U, "decimal-float-explicit-unchecked-variable-1");
        }
        {
            decimal input = 0m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "decimal-float-explicit-unchecked-variable-2");
        }
        {
            decimal input = 1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "decimal-float-explicit-unchecked-variable-3");
        }
        {
            decimal input = -1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "decimal-float-explicit-unchecked-variable-4");
        }
        {
            decimal input = 0.1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1036831949U, "decimal-float-explicit-unchecked-variable-5");
        }
        {
            decimal input = -0.1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3184315597U, "decimal-float-explicit-unchecked-variable-6");
        }
        {
            decimal input = 1E-28m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==285050806U, "decimal-float-explicit-unchecked-variable-7");
        }
        {
            decimal input = -1E-28m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2432534454U, "decimal-float-explicit-unchecked-variable-8");
        }
        {
            decimal input = 16777215m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "decimal-float-explicit-unchecked-variable-9");
        }
        {
            decimal input = 16777216m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "decimal-float-explicit-unchecked-variable-10");
        }
        {
            decimal input = 16777217m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "decimal-float-explicit-unchecked-variable-11");
        }
        {
            decimal input = -16777217m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "decimal-float-explicit-unchecked-variable-12");
        }
        {
            decimal input = -16777216m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "decimal-float-explicit-unchecked-variable-13");
        }
        {
            decimal input = -16777215m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "decimal-float-explicit-unchecked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
