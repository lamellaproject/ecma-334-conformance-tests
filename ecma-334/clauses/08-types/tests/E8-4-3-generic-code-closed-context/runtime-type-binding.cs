/*
Rules: E8-4-3-generic-code-closed-context; E8-4-3-generic-parameter-runtime-binding; E8-4-3-runtime-types-closed; E8-4-3-open-types-compile-time-only; E8-5-type-parameter-definition; E8-5-type-parameter-form; E8-5-type-parameters-compile-time; E8-5-type-parameter-runtime-type; E8-5-type-parameter-variable-closed; E8-5-type-parameter-execution-type
Authority: ECMA-334 7th ed 8.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return input;
Into: return default(T);
*/
using System;
// 8.5, p. 86 calls every substituted run-time type a closed constructed type.
// Nongeneric arguments are closed types too; this test follows the next sentence,
// which executes using the supplied type argument.
class Box<T> { public static T Read(T input) { return input; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object value = Box<int>.Read(62); object reference = Box<string>.Read("bound");
        Check(value.GetType() == typeof(int) && (int)value == 62, "value-parameter-bound-to-int");
        Check(reference.GetType() == typeof(string) && (string)reference == "bound", "reference-parameter-bound-to-string");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
