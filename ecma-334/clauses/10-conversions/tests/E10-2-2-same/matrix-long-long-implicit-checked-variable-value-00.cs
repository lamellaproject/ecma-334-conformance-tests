/*
Rules: E10-2-2-same
Authority: ECMA-334 7th ed 10.2.2
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
            long input = long.MinValue;
            long result = checked(input);
            Check(result==long.MinValue, "long-long-implicit-checked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            long result = checked(input);
            Check(result==9223372036854775807L, "long-long-implicit-checked-variable-1");
        }
        { long input = 0L; long result = checked(input); Check(result==0L, "long-long-implicit-checked-variable-2"); }
        { long input = 1L; long result = checked(input); Check(result==1L, "long-long-implicit-checked-variable-3"); }
        { long input = -1L; long result = checked(input); Check(result==-1L, "long-long-implicit-checked-variable-4"); }
        {
            long input = -9223372036854775807L;
            long result = checked(input);
            Check(result==-9223372036854775807L, "long-long-implicit-checked-variable-5");
        }
        {
            long input = 9223372036854775806L;
            long result = checked(input);
            Check(result==9223372036854775806L, "long-long-implicit-checked-variable-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
