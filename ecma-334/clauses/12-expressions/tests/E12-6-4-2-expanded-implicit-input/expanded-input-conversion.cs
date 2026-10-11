/*
Rules: E12-6-4-2-expanded-implicit-input
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Sum(input, 3, 5)
Into: Sum(in input, 3, 5)
*/
using System;
class Program
{
    static int checks, failures;
    static long Sum(in long first, params int[] tail) { return first + tail[0] + tail[1]; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        short input = 2;
        Check(Sum(input, 3, 5) == 10L, "expanded-call-omitted-input-mode-allows-implicit-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
