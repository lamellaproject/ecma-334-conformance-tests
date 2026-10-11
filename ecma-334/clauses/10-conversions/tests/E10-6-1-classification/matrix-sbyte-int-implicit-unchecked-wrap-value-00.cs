/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            sbyte input = (sbyte)(-128);
            int? result = unchecked(input);
            Check(result.HasValue && result.Value==-128, "nullable-sbyte-int-implicit-unchecked-wrap-0");
        }
        {
            sbyte input = (sbyte)(127);
            int? result = unchecked(input);
            Check(result.HasValue && result.Value==127, "nullable-sbyte-int-implicit-unchecked-wrap-1");
        }
        {
            sbyte input = (sbyte)(0);
            int? result = unchecked(input);
            Check(result.HasValue && result.Value==0, "nullable-sbyte-int-implicit-unchecked-wrap-2");
        }
        {
            sbyte input = (sbyte)(1);
            int? result = unchecked(input);
            Check(result.HasValue && result.Value==1, "nullable-sbyte-int-implicit-unchecked-wrap-3");
        }
        {
            sbyte input = (sbyte)(-1);
            int? result = unchecked(input);
            Check(result.HasValue && result.Value==-1, "nullable-sbyte-int-implicit-unchecked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
