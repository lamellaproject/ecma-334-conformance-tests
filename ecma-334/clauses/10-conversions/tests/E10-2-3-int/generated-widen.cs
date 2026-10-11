/*
Rules: E10-2-3-int; E10-2-3-exact
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
        { int input = -2147483648; long output = input; Check(output == -2147483648L, "int-long-00"); }
        { int input = -65537; long output = input; Check(output == -65537L, "int-long-01"); }
        { int input = -32769; long output = input; Check(output == -32769L, "int-long-02"); }
        { int input = -257; long output = input; Check(output == -257L, "int-long-03"); }
        { int input = -129; long output = input; Check(output == -129L, "int-long-04"); }
        { int input = -1; long output = input; Check(output == -1L, "int-long-05"); }
        { int input = 0; long output = input; Check(output == 0L, "int-long-06"); }
        { int input = 1; long output = input; Check(output == 1L, "int-long-07"); }
        { int input = 2; long output = input; Check(output == 2L, "int-long-08"); }
        { int input = 127; long output = input; Check(output == 127L, "int-long-09"); }
        { int input = 128; long output = input; Check(output == 128L, "int-long-10"); }
        { int input = 255; long output = input; Check(output == 255L, "int-long-11"); }
        { int input = 256; long output = input; Check(output == 256L, "int-long-12"); }
        { int input = 32768; long output = input; Check(output == 32768L, "int-long-13"); }
        { int input = 65536; long output = input; Check(output == 65536L, "int-long-14"); }
        { int input = 2147483647; long output = input; Check(output == 2147483647L, "int-long-15"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
