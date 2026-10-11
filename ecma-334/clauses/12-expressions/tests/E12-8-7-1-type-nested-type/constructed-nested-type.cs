/*
Rules: E12-8-7-1-type-nested-type; E12-8-7-1-type-lookup
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Shell.Nested<int>.Value
Into: Shell.Nested.Value
*/
using System;
class Shell
{
    public class Nested { public static int Value = 8; }
    public class Nested<T> { public static int Value = 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Shell.Nested<int>.Value;
        Check(result == 3, "type-member-access-constructs-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
