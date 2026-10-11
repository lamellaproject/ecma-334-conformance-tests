/*
Rules: E6-2-5-generic-unselected-parse
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Left<Right>+Boundary
Into: Left<Right>(Boundary)
*/
using System;
struct Measure
{
    public int Number;
    public Measure(int number) { Number = number; }
    public static Measure operator <(Measure left, Measure right) { return new Measure(left.Number + right.Number); }
    public static Measure operator >(Measure left, Measure right) { return new Measure(left.Number - right.Number); }
    public static Measure operator +(Measure value) { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Measure Left = new Measure(4), Right = new Measure(7), Boundary = new Measure(9);
        Measure result = Left<Right>+Boundary;
        Check(result.Number == 2, "plus-discards-generic-parse");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
