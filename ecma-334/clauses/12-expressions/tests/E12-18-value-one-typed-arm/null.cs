/*
Rules: E12-18-value-one-typed-arm
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: takeLeft ? text : null
Into: takeLeft ? (object)text : null
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsString<T>(T value) { return typeof(T) == typeof(string); }
    static void Main()
    {
        bool takeLeft = false;
        string text = "text";
        var result = takeLeft ? text : null;
        Check(IsString(result), "untyped-null-uses-string-arm-type");
        Check(result == null, "null-selected-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
