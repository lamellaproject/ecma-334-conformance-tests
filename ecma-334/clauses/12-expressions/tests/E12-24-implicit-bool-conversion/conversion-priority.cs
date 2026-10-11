/*
Rules: E12-24-implicit-bool-conversion; E12-24-bool-result; E12-24-form; E12-24-conditional-same-rules
Authority: ECMA-334 7th ed 12.24
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static implicit operator bool
Into: public static explicit operator bool
*/
using System;
struct Flag
{
    bool value;
    public Flag(bool value) { this.value = value; }
    public static implicit operator bool(Flag flag) { Program.trace += "C"; return flag.value; }
    public static bool operator true(Flag flag) { Program.trace += "T"; return true; }
    public static bool operator false(Flag flag) { Program.trace += "F"; return false; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int entered = 0;
        if (new Flag(false)) entered++;
        Check(entered == 0 && trace == "C", "implicit-conversion-before-true-operator");
        trace = "";
        int picked = new Flag(true) ? 13 : 17;
        Check(picked == 13 && trace == "C", "conditional-uses-same-conversion-priority");
        bool direct = true;
        if (direct) entered++;
        Check(entered == 1, "direct-bool-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
