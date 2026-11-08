/*
Rules: E23-7-ed4-captured-body-read
Authority: ECMA-334 4th ed 27.6
Version: ISO-2
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E23-7-ed4-captured-body-read/captured-local-in-body.cs.part
Mutate: int observed = captured;
Into: int observed = 0;
*/
// ECMA-334 4th ed 27.6, p. 437 (PDF p. 459).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    delegate int ReadValue();
    static unsafe void Observe()
    {
        int captured = 29;
        ReadValue callback = delegate { return captured; };
        int[] data = new int[] { 31 };
        fixed (int* pointer = data)
        {
            int observed = captured;
            Check(observed == 29, "captured-local-body-read");
            Check(*pointer == 31, "unrelated-fixed-initializer");
        }
        Check(callback() == 29, "capture-control");
    }
    static int Main()
    {
        Observe();
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
