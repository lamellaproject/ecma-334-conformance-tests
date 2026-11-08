/*
Rules: E12-12-9-ed3-distinct-anonymous-entries
Authority: ECMA-334 3rd ed 14.9.8
Version: ISO-2
Expected: run
Stdout: OK 4
Mutate: Capture(seed + 0)
Into: first
*/
// ECMA-334 3rd ed 14.9.8, p. 209 (PDF p. 229).
using System;
delegate int ReadValue();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static ReadValue Capture(int value) { return delegate { return value; }; }
    static int Main()
    {
        int seed = 19;
        ReadValue first = Capture(seed);
        ReadValue second = Capture(seed + 0);
        Check(first() == 19 && second() == 19, "capture-values");
        Check(first != second, "different-capture-instances");
        int offset = 2;
        ReadValue low = delegate { return offset; };
        ReadValue high = delegate { return offset + 3; };
        Check(low() == 2 && high() == 5, "different-body-values");
        Check(low != high, "different-anonymous-bodies");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
