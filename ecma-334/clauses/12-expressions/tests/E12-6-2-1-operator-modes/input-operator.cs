/*
Rules: E12-6-2-1-operator-modes
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operator +(in Box left, in Box right)
Into: operator -(in Box left, in Box right)
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static Box operator +(in Box left, in Box right) { return new Box(left.value * 10 + right.value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box left = new Box(3), right = new Box(7); Box result = left + right;
        Check(result.value == 37, "input-operator-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
