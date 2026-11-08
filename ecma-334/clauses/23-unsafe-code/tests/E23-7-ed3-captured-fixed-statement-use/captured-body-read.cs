/*
Rules: E23-7-ed3-captured-fixed-statement-use
Authority: ECMA-334 3rd ed 27.6
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E23-7-ed3-captured-fixed-statement-use/captured-body-read.cs.part
Mutate: int observed = captured;
Into: int observed = 23;
*/
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
        int captured = 23;
        ReadValue callback = delegate { return captured; };
        int[] data = new int[] { 31 };
        fixed (int* pointer = data)
        {
            int observed = captured;
            Check(observed == 23, "captured-body-read");
            Check(*pointer == 31, "unrelated-storage-control");
        }
        Check(callback() == 23, "capture-control");
    }
    static int Main()
    {
        Observe();
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
