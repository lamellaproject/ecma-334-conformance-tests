/*
Rules: E12-4-3-fixed-precedence; E12-4-3-fixed-associativity
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Box first = a + b * c;
Into: Box first = (a + b) * c;
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static Box operator +(Box x, Box y) { return new Box(x.value + y.value); }
    public static Box operator *(Box x, Box y) { return new Box(x.value * y.value); }
    public static Box operator -(Box x, Box y) { return new Box(x.value - y.value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box a = new Box(23), b = new Box(7), c = new Box(3);
        Box first = a + b * c; Box second = a - b - c;
        Check(first.value == 44, "user-operator-fixed-precedence");
        Check(second.value == 13, "user-operator-fixed-associativity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
