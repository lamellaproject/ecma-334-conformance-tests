/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            decimal? input = -79228162514264337593543950335m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==4018143232U, "nullable-decimal-float-explicit-unchecked-unwrap-0");
        }
        {
            decimal? input = 79228162514264337593543950335m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1870659584U, "nullable-decimal-float-explicit-unchecked-unwrap-1");
        }
        {
            decimal? input = 0m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nullable-decimal-float-explicit-unchecked-unwrap-2");
        }
        {
            decimal? input = 1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nullable-decimal-float-explicit-unchecked-unwrap-3");
        }
        {
            decimal? input = -1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "nullable-decimal-float-explicit-unchecked-unwrap-4");
        }
        {
            decimal? input = 0.1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1036831949U, "nullable-decimal-float-explicit-unchecked-unwrap-5");
        }
        {
            decimal? input = -0.1m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3184315597U, "nullable-decimal-float-explicit-unchecked-unwrap-6");
        }
        {
            decimal? input = 1E-28m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==285050806U, "nullable-decimal-float-explicit-unchecked-unwrap-7");
        }
        {
            decimal? input = -1E-28m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2432534454U, "nullable-decimal-float-explicit-unchecked-unwrap-8");
        }
        {
            decimal? input = 16777215m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "nullable-decimal-float-explicit-unchecked-unwrap-9");
        }
        {
            decimal? input = 16777216m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nullable-decimal-float-explicit-unchecked-unwrap-10");
        }
        {
            decimal? input = 16777217m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nullable-decimal-float-explicit-unchecked-unwrap-11");
        }
        {
            decimal? input = -16777217m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nullable-decimal-float-explicit-unchecked-unwrap-12");
        }
        {
            decimal? input = -16777216m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nullable-decimal-float-explicit-unchecked-unwrap-13");
        }
        {
            decimal? input = -16777215m;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "nullable-decimal-float-explicit-unchecked-unwrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
