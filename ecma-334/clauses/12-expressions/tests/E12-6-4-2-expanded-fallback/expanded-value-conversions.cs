/*
Rules: E12-6-4-2-expanded-fallback; E12-6-4-2-expanded-parameters; E12-6-4-2-expanded-value
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Sum((short)2, 3, 4L)
Into: Sum((short)2, 3)
*/
using System;
class Program
{
    static int checks, failures;
    static long Sum(int first, params long[] tail) { return first + tail.Length * 100L + tail[0]; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Sum((short)2, 3, 4L) == 205L, "expanded-form-replaces-array-with-convertible-element-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
