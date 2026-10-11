/*
Rules: P09-native-nint-long
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
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
        { nint input = -2147483648; long output = input; Check(output == -2147483648L, "nint-long-00"); }
        { nint input = -65537; long output = input; Check(output == -65537L, "nint-long-01"); }
        { nint input = -32769; long output = input; Check(output == -32769L, "nint-long-02"); }
        { nint input = -257; long output = input; Check(output == -257L, "nint-long-03"); }
        { nint input = -129; long output = input; Check(output == -129L, "nint-long-04"); }
        { nint input = -1; long output = input; Check(output == -1L, "nint-long-05"); }
        { nint input = 0; long output = input; Check(output == 0L, "nint-long-06"); }
        { nint input = 1; long output = input; Check(output == 1L, "nint-long-07"); }
        { nint input = 2; long output = input; Check(output == 2L, "nint-long-08"); }
        { nint input = 127; long output = input; Check(output == 127L, "nint-long-09"); }
        { nint input = 128; long output = input; Check(output == 128L, "nint-long-10"); }
        { nint input = 255; long output = input; Check(output == 255L, "nint-long-11"); }
        { nint input = 256; long output = input; Check(output == 256L, "nint-long-12"); }
        { nint input = 32768; long output = input; Check(output == 32768L, "nint-long-13"); }
        { nint input = 65536; long output = input; Check(output == 65536L, "nint-long-14"); }
        { nint input = 2147483647; long output = input; Check(output == 2147483647L, "nint-long-15"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
