/*
Rules: E19-6-full-value-set; E19-6-cast-any-underlying-value
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (Code)raw
Into: Code.Named
*/
using System;
enum Code : byte { Named = 11 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte raw = 200; Code unnamed = (Code)raw;
        Check((byte)unnamed == 200 && unnamed != Code.Named, "unnamed-value-valid");
        Check((byte)(Code)255 == 255, "unnamed-maximum-valid");
        Check((byte)(Code)0 == 0, "unnamed-zero-valid");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
