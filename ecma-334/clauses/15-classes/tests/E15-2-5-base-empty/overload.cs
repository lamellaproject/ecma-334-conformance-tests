/*
Rules: E15-2-5-base-empty
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static int Read<T>(T value)
Into: static int Read<T>(T value) where T : struct
*/
using System;
class Program
{
    static int Pick(object value) { return 1; }
    static int Pick(ValueType value) { return 2; }
    static int Read<T>(T value) { return Pick(value); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(239) == 1, "empty-candidate-set-has-object-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
