/*
Rules: P09-native-decimal-nint; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 13
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            decimal? input = 0m;
            nint result = checked((nint)input);
            Check((long)result==0L, "decimal-nint-explicit-checked-unwrap-2");
        }
        {
            decimal? input = 1m;
            nint result = checked((nint)input);
            Check((long)result==1L, "decimal-nint-explicit-checked-unwrap-3");
        }
        {
            decimal? input = -1m;
            nint result = checked((nint)input);
            Check((long)result==-1L, "decimal-nint-explicit-checked-unwrap-4");
        }
        {
            decimal? input = 0.1m;
            nint result = checked((nint)input);
            Check((long)result==0L, "decimal-nint-explicit-checked-unwrap-5");
        }
        {
            decimal? input = -0.1m;
            nint result = checked((nint)input);
            Check((long)result==0L, "decimal-nint-explicit-checked-unwrap-6");
        }
        {
            decimal? input = 1E-28m;
            nint result = checked((nint)input);
            Check((long)result==0L, "decimal-nint-explicit-checked-unwrap-7");
        }
        {
            decimal? input = -1E-28m;
            nint result = checked((nint)input);
            Check((long)result==0L, "decimal-nint-explicit-checked-unwrap-8");
        }
        {
            decimal? input = -9223372036854775808m;
            nint result = checked((nint)input);
            Check((long)result==long.MinValue, "decimal-nint-explicit-checked-unwrap-10");
        }
        {
            decimal? input = -9223372036854775807m;
            nint result = checked((nint)input);
            Check((long)result==-9223372036854775807L, "decimal-nint-explicit-checked-unwrap-11");
        }
        {
            decimal? input = 9223372036854775806m;
            nint result = checked((nint)input);
            Check((long)result==9223372036854775806L, "decimal-nint-explicit-checked-unwrap-12");
        }
        {
            decimal? input = 9223372036854775807m;
            nint result = checked((nint)input);
            Check((long)result==9223372036854775807L, "decimal-nint-explicit-checked-unwrap-13");
        }
        {
            decimal? input = -9223372036854775808.75m;
            nint result = checked((nint)input);
            Check((long)result==long.MinValue, "decimal-nint-explicit-checked-unwrap-15");
        }
        {
            decimal? input = 9223372036854775807.75m;
            nint result = checked((nint)input);
            Check((long)result==9223372036854775807L, "decimal-nint-explicit-checked-unwrap-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
