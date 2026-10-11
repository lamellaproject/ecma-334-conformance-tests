/*
Rules: E12-12-1-overload-resolution; E12-12-1-operand-conversions; E12-12-1-result-type
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: left == right
Into: left != right
*/
using System;
struct Answer { public int Value; public Answer(int value) { Value = value; } }
class Number
{
    public static Answer operator ==(Number x, int y) { return new Answer(11 + y); }
    public static Answer operator !=(Number x, int y) { return new Answer(21 + y); }
    public static Answer operator <(Number x, int y) { return new Answer(31 + y); }
    public static Answer operator >(Number x, int y) { return new Answer(41 + y); }
    public static Answer operator <=(Number x, int y) { return new Answer(51 + y); }
    public static Answer operator >=(Number x, int y) { return new Answer(61 + y); }
    public static Answer operator ==(Number x, long y) { return new Answer(-1); }
    public static Answer operator !=(Number x, long y) { return new Answer(-1); }
    public static Answer operator <(Number x, long y) { return new Answer(-1); }
    public static Answer operator >(Number x, long y) { return new Answer(-1); }
    public static Answer operator <=(Number x, long y) { return new Answer(-1); }
    public static Answer operator >=(Number x, long y) { return new Answer(-1); }
    public override bool Equals(object x) { return (object)this == x; }
    public override int GetHashCode() { return 0; }
}
class Narrow : Number { }
struct Input { public static implicit operator int(Input x) { Program.Conversions++; return 4; } }
class Program
{
    public static int Conversions;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Answer x) { return 1; }
    static int Kind(object x) { return 2; }
    static void Main()
    {
        Narrow left = new Narrow(); Input right = new Input(); var r = left == right;
        Check(r.Value == 15 && Kind(r) == 1, "equality-return-and-better-int");
        Check((left != right).Value == 25, "inequality"); Check((left < right).Value == 35, "less");
        Check((left > right).Value == 45, "greater"); Check((left <= right).Value == 55, "less-equal");
        Check((left >= right).Value == 65, "greater-equal");
        Check(Conversions == 6, "each-operand-converted-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
