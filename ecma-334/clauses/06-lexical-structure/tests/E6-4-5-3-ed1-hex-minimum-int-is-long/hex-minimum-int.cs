/*
Rules: E6-4-5-3-ed1-hex-minimum-int-is-long
Authority: ECMA-334 1st ed 9.4.4.2
Version: ISO-1
Expected: run
Stdout: OK 1
Diagnostic: none
Version-Witness: tests/E6-4-5-3-ed1-hex-minimum-int-is-long/hex-minimum-int.witness.cs.part
Mutate: -0x80000000
Into: -2147483648
*/
// ECMA-334 1st ed 9.4.4.2, p. 58 (PDF p. 72), lines 25-29. Unsuffixed
// hexadecimal0x80000000 is uint; unary negation gives long, because the special int
// minimum applies only to decimal spelling.
using System;
class Entry
{
    static int checks;
    static int failures;
    static int Pick(int value) { return 1; }
    static int Pick(long value) { return 2; }
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Main()
    {
        Check(Pick(-0x80000000) == 2, "hex-negation-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
