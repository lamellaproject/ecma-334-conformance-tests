/*
Rules: E12-10-5-null-operand; E12-10-5-null-tostring; E12-10-5-nonnull-string
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: nullString + value
Into: nullString
*/
using System;
class EmptyText { public override string ToString() { Program.Calls++; return null; } }
class Program
{
    public static int Calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string nullString = null, value = "ab"; object nullObject = null, empty = new EmptyText();
        Check(nullString + value == "ab", "null-string-left");
        Check(value + nullString == "ab", "null-string-right");
        Check(nullObject + value == "ab", "null-object-left");
        Check(value + nullObject == "ab", "null-object-right");
        string r = nullString + nullString; Check(r != null && r == "", "both-null-result-nonnull");
        Check(empty + value == "ab", "null-tostring-left");
        Check(value + empty == "ab" && Calls == 2, "null-tostring-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
