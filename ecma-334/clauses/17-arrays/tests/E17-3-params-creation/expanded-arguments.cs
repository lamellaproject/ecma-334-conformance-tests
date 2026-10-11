/*
Rules: E17-3-params-creation
Authority: ECMA-334 7th ed 17.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Capture(13, 28)
Into: Capture(13)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int[] Capture(params int[] items) { return items; }
    static void Main()
    {
        int[] first = Capture(13, 28);
        int[] second = Capture(13, 29);
        Check(first.Length == 2, "expanded-length");
        Check(first[0] == 13 && first[1] == 28, "expanded-values");
        Check(first != second && second[1] == 29, "expanded-fresh-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
