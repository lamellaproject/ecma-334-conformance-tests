/*
Rules: E6-4-6-grammar-operator-or-punctuator-25
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: input ?? Right()
Into: Right()
*/
using System;
class Program
{
    static int checks, failures, visits;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static string Right() { visits++; return "right"; }
    static string Choose(string input) { return input ?? Right(); }
    static void Main()
    {
        string first = Choose("left");
        Check(first == "left" && visits == 0, "non-null-left");
        string second = Choose(null);
        Check(second == "right" && visits == 1, "null-left");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
