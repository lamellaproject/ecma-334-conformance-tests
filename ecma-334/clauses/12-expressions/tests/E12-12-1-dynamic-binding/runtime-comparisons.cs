/*
Rules: E12-12-1-dynamic-binding; E12-12-1-dynamic-result-type; E12-12-1-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: operand == right
Into: operand != right
*/
using System;
public class Answer { public int Value; public Answer(int v) { Value = v; } }
public class Number
{
    public static Answer operator ==(Number x, int y) { return new Answer(y + 10); }
    public static Answer operator !=(Number x, int y) { return new Answer(y + 20); }
    public static Answer operator <(Number x, int y) { return new Answer(y + 30); }
    public static Answer operator >(Number x, int y) { return new Answer(y + 40); }
    public static Answer operator <=(Number x, int y) { return new Answer(y + 50); }
    public static Answer operator >=(Number x, int y) { return new Answer(y + 60); }
    public override bool Equals(object x) { return (object)this == x; }
    public override int GetHashCode() { return 0; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(Answer x) { return 1; }
    static int Pick(object x) { return 2; }
    static void Main()
    {
        dynamic operand = new Number(); int right = 4; var r = operand == right;
        Check(r.Value == 14, "runtime-equality"); Check(Pick(r) == 1, "dynamic-comparison-result");
        Check((operand != right).Value == 24, "runtime-inequality"); Check((operand < right).Value == 34, "runtime-less");
        Check((operand > right).Value == 44, "runtime-greater"); Check((operand <= right).Value == 54, "runtime-less-equal");
        Check((operand >= right).Value == 64, "runtime-greater-equal");
        operand = 3; Check(operand < right, "changed-runtime-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
