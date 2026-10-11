/*
Rules: E12-18-value-identity-common-type
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: takeLeft ? left : right
Into: takeLeft ? (long)left : right
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsInt<T>(T value) { return typeof(T) == typeof(int); }
    static void Main()
    {
        bool takeLeft = false;
        int left = 11, right = 19;
        var result = takeLeft ? left : right;
        Check(IsInt(result), "identity-best-common-static-int");
        Check(result == 19, "identity-selected-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
