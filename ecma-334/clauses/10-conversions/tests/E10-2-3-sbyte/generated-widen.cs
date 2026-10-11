/*
Rules: E10-2-3-sbyte; E10-2-3-exact
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 16
Generated: clauses/10-conversions/generators/sample-matrix.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        { sbyte input = -128; long output = input; Check(output == -128L, "sbyte-long-00"); }
        { sbyte input = -127; long output = input; Check(output == -127L, "sbyte-long-01"); }
        { sbyte input = -100; long output = input; Check(output == -100L, "sbyte-long-02"); }
        { sbyte input = -65; long output = input; Check(output == -65L, "sbyte-long-03"); }
        { sbyte input = -64; long output = input; Check(output == -64L, "sbyte-long-04"); }
        { sbyte input = -2; long output = input; Check(output == -2L, "sbyte-long-05"); }
        { sbyte input = -1; long output = input; Check(output == -1L, "sbyte-long-06"); }
        { sbyte input = 0; long output = input; Check(output == 0L, "sbyte-long-07"); }
        { sbyte input = 1; long output = input; Check(output == 1L, "sbyte-long-08"); }
        { sbyte input = 2; long output = input; Check(output == 2L, "sbyte-long-09"); }
        { sbyte input = 16; long output = input; Check(output == 16L, "sbyte-long-10"); }
        { sbyte input = 63; long output = input; Check(output == 63L, "sbyte-long-11"); }
        { sbyte input = 64; long output = input; Check(output == 64L, "sbyte-long-12"); }
        { sbyte input = 100; long output = input; Check(output == 100L, "sbyte-long-13"); }
        { sbyte input = 126; long output = input; Check(output == 126L, "sbyte-long-14"); }
        { sbyte input = 127; long output = input; Check(output == 127L, "sbyte-long-15"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
