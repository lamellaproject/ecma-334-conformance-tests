/*
Rules: E12-6-6-1-box-enum-type; E12-6-6-1-box-value
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: original.GetType()
Into: Other.Value.GetType()
*/
using System;
enum Mode { Value = 3 }
enum Other { Value = 8 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Mode original = Mode.Value;
        Type result = original.GetType();
        Check(result == typeof(Mode), "inherited-member-observes-boxed-enum-runtime-type");
        Check(original == Mode.Value, "inherited-member-leaves-enum-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
