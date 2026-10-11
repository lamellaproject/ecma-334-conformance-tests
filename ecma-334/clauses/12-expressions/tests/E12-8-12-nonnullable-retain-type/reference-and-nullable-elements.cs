/*
Rules: E12-8-12-nonnullable-retain-type; E12-8-12-nonnullable-retain-null; E12-8-12-nonnullable-retain-present
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: full?[0]
Into: empty?[0]
*/
using System;
class Program
{
    static int checks, failures;
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] full = new string[] { "fir" }, empty = null;
        var text = full?[0];
        Check(Kind(text) == 1 && text == "fir", "reference-array-element-type-retained");
        var absent = empty?[1];
        Check(Kind(absent) == 1 && absent == null, "absent-reference-array-result-null");
        int?[] numbers = new int?[] { 59 }, noNumbers = null;
        int? number = numbers?[0];
        Check(number == 59, "already-nullable-array-element-type-retained");
        number = noNumbers?[0];
        Check(!number.HasValue, "absent-array-retains-nullable-element-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
