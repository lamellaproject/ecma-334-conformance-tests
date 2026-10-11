/*
Rules: E16-3-member-operator
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operator +
Into: operator -
*/
using System;
struct Entry
{
    public int Value;
    public static Entry operator +(Entry left, Entry right)
    {
        Entry result = new Entry(); result.Value = left.Value + right.Value; return result;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry left = new Entry(); left.Value = 19;
        Entry right = new Entry(); right.Value = 28;
        Entry result = left + right;
        Check(result.Value == 47, "struct-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
