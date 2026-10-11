/*
Rules: E12-18-value-x-to-y
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: takeLeft ? left : right
Into: takeLeft ? left : (int)right
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsLong<T>(T value) { return typeof(T) == typeof(long); }
    static void Main()
    {
        bool takeLeft = true;
        int left = 17;
        long right = 29;
        var result = takeLeft ? left : right;
        Check(IsLong(result), "one-way-x-to-y-selects-long");
        Check(result == 17L, "x-is-converted-to-y");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
