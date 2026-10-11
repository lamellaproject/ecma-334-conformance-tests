/*
Rules: E10-2-2-same; E12-23-numeric
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
            const long input = long.MinValue;
            long result = checked(input);
            Check(result==long.MinValue, "long-long-implicit-checked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            long result = checked(input);
            Check(result==9223372036854775807L, "long-long-implicit-checked-constant-1");
        }
        {
            const long input = 0L;
            long result = checked(input);
            Check(result==0L, "long-long-implicit-checked-constant-2");
        }
        {
            const long input = 1L;
            long result = checked(input);
            Check(result==1L, "long-long-implicit-checked-constant-3");
        }
        {
            const long input = -1L;
            long result = checked(input);
            Check(result==-1L, "long-long-implicit-checked-constant-4");
        }
        {
            const long input = -9223372036854775807L;
            long result = checked(input);
            Check(result==-9223372036854775807L, "long-long-implicit-checked-constant-5");
        }
        {
            const long input = 9223372036854775806L;
            long result = checked(input);
            Check(result==9223372036854775806L, "long-long-implicit-checked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
