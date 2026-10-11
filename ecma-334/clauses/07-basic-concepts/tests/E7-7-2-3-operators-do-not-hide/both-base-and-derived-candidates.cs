/*
Rules: E7-7-2-3-operators-do-not-hide
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: operator +(Branch left, Branch right)
Into: operator -(Branch left, Branch right)
*/
using System;
class Root { public static int operator +(Root left, Root right) { return 109; } }
class Branch : Root { public static int operator +(Branch left, Branch right) { return 113; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root first = new Root();
        Branch second = new Branch();
        Check(first + first == 109, "base-operator");
        Check(second + second == 113, "derived-operator-with-different-signature");
        Check(first + second == 109, "base-operator-with-derived-right-operand");
        Check(second + first == 109, "base-operator-with-derived-left-operand");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
