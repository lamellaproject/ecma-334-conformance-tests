/*
Rules: E9-2-9-captured-local-lifetime
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: () => ++cell
Into: () => cell
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Func<int>[] Capture()
    {
        int cell = 40;
        return new Func<int>[] { () => ++cell, () => cell };
    }
    static void Main()
    {
        Func<int>[] views = Capture();
        Func<int> writer = views[0], reader = views[1];
        views = null;
        Check(writer() == 41, "captured-local-after-scope-exit");
        Check(reader() == 41, "other-object-still-references-same-local");
        Check(writer() == 42, "captured-storage-retains-updates");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
