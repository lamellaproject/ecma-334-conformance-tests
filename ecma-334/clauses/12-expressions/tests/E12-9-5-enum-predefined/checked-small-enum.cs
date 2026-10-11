/*
Rules: E12-9-5-enum-predefined; E12-9-5-enum-result; E12-9-5-enum-unchecked
Authority: ECMA-334 7th ed 12.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ~value
Into: value
*/
using System;
enum Mask : byte { Low = 3 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Mask x) { return 1; }
    static int Kind(int x) { return 2; }
    static void Main()
    {
        Mask value = Mask.Low; var result = checked(~value);
        Check((byte)result == 252, "unchecked-enum-conversion"); Check(Kind(result) == 1, "enum-result-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
