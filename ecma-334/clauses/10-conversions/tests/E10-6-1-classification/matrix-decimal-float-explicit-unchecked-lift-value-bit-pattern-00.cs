/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==4018143232U, "nullable-decimal-float-explicit-unchecked-lift-0");
        }
        {
            decimal? input = 79228162514264337593543950335m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1870659584U, "nullable-decimal-float-explicit-unchecked-lift-1");
        }
        {
            decimal? input = 0m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-decimal-float-explicit-unchecked-lift-2");
        }
        {
            decimal? input = 1m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-decimal-float-explicit-unchecked-lift-3");
        }
        {
            decimal? input = -1m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3212836864U, "nullable-decimal-float-explicit-unchecked-lift-4");
        }
        {
            decimal? input = 0.1m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1036831949U, "nullable-decimal-float-explicit-unchecked-lift-5");
        }
        {
            decimal? input = -0.1m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3184315597U, "nullable-decimal-float-explicit-unchecked-lift-6");
        }
        {
            decimal? input = 1E-28m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==285050806U, "nullable-decimal-float-explicit-unchecked-lift-7");
        }
        {
            decimal? input = -1E-28m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==2432534454U, "nullable-decimal-float-explicit-unchecked-lift-8");
        }
        {
            decimal? input = 16777215m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679807U, "nullable-decimal-float-explicit-unchecked-lift-9");
        }
        {
            decimal? input = 16777216m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-decimal-float-explicit-unchecked-lift-10");
        }
        {
            decimal? input = 16777217m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-decimal-float-explicit-unchecked-lift-11");
        }
        {
            decimal? input = -16777217m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-decimal-float-explicit-unchecked-lift-12");
        }
        {
            decimal? input = -16777216m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-decimal-float-explicit-unchecked-lift-13");
        }
        {
            decimal? input = -16777215m;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163455U, "nullable-decimal-float-explicit-unchecked-lift-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
