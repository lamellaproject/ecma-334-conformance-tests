/*
Rules: E12-18-value-enum-y-to-x
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: takeLeft ? left : 0
Into: takeLeft ? (int)left : 0
*/
using System;
enum Code { Zero, Other = 9 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsCode<T>(T value) { return typeof(T) == typeof(Code); }
    static void Main()
    {
        bool takeLeft = false;
        Code left = Code.Other;
        var result = takeLeft ? left : 0;
        Check(IsCode(result), "zero-last-arm-enum-static-type");
        Check((int)result == 0, "last-zero-enum-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
