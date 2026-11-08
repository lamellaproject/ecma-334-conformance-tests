/*
Rules: E13-9-5-ed3-shared-iteration-capture
Authority: ECMA-334 3rd ed 15.8.4
Version: ISO-2
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E13-9-5-ed3-shared-iteration-capture/array-iteration-instance.cs.part
Mutate: saved[index++] = delegate { return marker; };
Into: int frozen = marker; saved[index++] = delegate { return frozen; };
*/
// ECMA-334 3rd ed 15.8.4, p. 234 (PDF p. 254).
using System;
delegate int Readback();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        int[] values = new int[] { 7, 18, 43 };
        Readback[] saved = new Readback[3];
        int index = 0;
        foreach (int marker in values)
        {
            saved[index++] = delegate { return marker; };
        }
        for (int i = 0; i < saved.Length; i++)
        {
            Check(saved[i]() == 43, "shared-array-iteration");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
