/*
Rules: E12-18-value-one-typed-arm
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: takeLeft ? callback : (() => 19)
Into: takeLeft ? (() => 11) : (() => 19)
*/
using System;
delegate int Callback();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsCallback<T>(T value) { return typeof(T) == typeof(Callback); }
    static void Main()
    {
        bool takeLeft = false;
        Callback callback = () => 11;
        var result = takeLeft ? callback : (() => 19);
        Check(IsCallback(result), "typed-arm-supplies-lambda-delegate-type");
        Check(result() == 19, "converted-lambda-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
