/*
Rules: E12-18-value-enum-x-to-y
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: takeLeft ? 0 : right
Into: takeLeft ? 0 : (int)right
*/
using System;
enum Code { Zero, Other = 7 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsCode<T>(T value) { return typeof(T) == typeof(Code); }
    static void Main()
    {
        bool takeLeft = true;
        Code right = Code.Other;
        var result = takeLeft ? 0 : right;
        Check(IsCode(result), "zero-first-arm-enum-static-type");
        Check((int)result == 0, "zero-enum-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
