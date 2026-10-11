/*
Rules: E12-19-4-type-inference
Authority: ECMA-334 7th ed 12.19.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: () => 53
Into: () => 53L
*/
using System;
delegate T Result<T>();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T Evaluate<T>(Result<T> function) { return function(); }
    static bool IsInt<T>(T value) { return typeof(T) == typeof(int); }
    static void Main()
    {
        var result = Evaluate(() => 53);
        Check(IsInt(result), "lambda-output-infers-type-argument");
        Check(result == 53, "inferred-delegate-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
