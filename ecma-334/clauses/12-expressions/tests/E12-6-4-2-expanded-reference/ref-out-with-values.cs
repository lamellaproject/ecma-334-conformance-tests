/*
Rules: E12-6-4-2-expanded-reference
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Gather(ref total, out stamp, small, amount)
Into: Gather(total, out stamp, small, amount)
*/
// ECMA-334 7th ed 12.6.4.2, p. 176 (PDF p. 204).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Gather(ref int total, out int stamp, params long[] values)
    {
        total += values.Length;
        stamp = (int)(values[0] + values[1]);
        return values.Length;
    }
    static int Main()
    {
        int total = 37, stamp;
        short small = 11;
        int amount = 19;
        int count = Gather(ref total, out stamp, small, amount);
        Check(total == 39, "fixed-reference");
        Check(stamp == 30, "fixed-output");
        Check(count == 2, "expanded-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
