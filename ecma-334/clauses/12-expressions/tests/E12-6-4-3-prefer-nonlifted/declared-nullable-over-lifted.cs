/*
Rules: E12-6-4-3-prefer-nonlifted
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (Number?)left + (Number?)right
Into: left + right
*/
using System;
struct Number
{
    public int value;
    public static Number operator +(Number x, Number y) { return new Number { value = 1 }; }
    public static Number? operator +(Number? x, Number? y) { return new Number { value = 2 }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Number left = new Number(), right = new Number();
        Number? result = (Number?)left + (Number?)right;
        Check(result.HasValue && result.Value.value == 2, "declared-nullable-operator-beats-identical-lifted-form");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
