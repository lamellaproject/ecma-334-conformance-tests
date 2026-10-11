/*
Rules: E12-8-15-overload-postfix; E12-8-15-overload-prefix
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Counter old = value++;
Into: Counter old = ++value;
*/
using System;
struct Counter
{
    public int Value;
    public Counter(int value) { Value = value; }
    public static Counter operator++(Counter value) { Program.trace += "P"; return new Counter(value.Value + 4); }
    public static Counter operator--(Counter value) { Program.trace += "M"; return new Counter(value.Value - 4); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value = new Counter(3);
        Counter old = value++;
        Counter next = ++value;
        Counter before = value--;
        Counter end = --value;
        Check(old.Value == 3, "postfix-increment-uses-same-operator-with-old-result");
        Check(next.Value == 11, "prefix-increment-uses-same-operator-with-new-result");
        Check(before.Value == 11, "postfix-decrement-uses-same-operator-with-old-result");
        Check(end.Value == 3 && value.Value == 3, "prefix-decrement-uses-same-operator-with-new-result");
        Check(trace == "PPMM", "both-notations-invoke-identical-implementations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
