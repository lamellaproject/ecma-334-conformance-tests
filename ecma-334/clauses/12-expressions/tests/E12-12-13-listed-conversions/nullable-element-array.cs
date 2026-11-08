/*
Rules: E12-12-13-listed-conversions; E12-12-12-1-runtime-check
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source as int?[]
Into: null as int?[]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object source = new int?[] { 37, null };
        Check(source is int?[], "is-nullable-element-array");
        int?[] result = source as int?[];
        Check(result != null && result.Length == 2 && result[0] == 37 && result[1] == null, "as-nullable-element-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
