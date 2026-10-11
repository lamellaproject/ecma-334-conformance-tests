/*
Rules: E12-4-5-binary-identity-merge
Authority: ECMA-334 7th ed 12.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left + right
Into: left - right
*/
using System;
struct Box<T>
{
    public int value;
    public Box(int n) { value = n; }
    public static int operator +(Box<T> x, Box<T> y) { return x.value + y.value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<dynamic> left = new Box<dynamic>(7); Box<object> right = new Box<object>(11);
        int result = left + right;
        Check(result == 18, "identity-equivalent-candidates-merged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
