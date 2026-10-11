/*
Rules: E12-12-11-pairwise-lexical; E12-12-11-operator-classification; E12-12-11-tuple-expression-elements; E12-12-11-tuple-value-elements; E12-12-11-equality-left-evaluation; E12-12-11-equality-right-evaluation; E12-12-11-equality-element-operation; E12-12-11-equality-bool-result; E12-12-11-equality-short-circuit; E12-12-11-equality-false-result; E12-12-11-equality-all-true
Authority: ECMA-334 7th ed 12.12.11
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: == Right()
Into: != Right()
*/
using System;
struct Number
{
    public int Value; public string Label;
    public Number(int v, string label) { Value = v; Label = label; }
    public static bool operator ==(Number x, Number y) { Program.Trace += "=" + x.Label + y.Label; return x.Value == y.Value; }
    public static bool operator !=(Number x, Number y) { Program.Trace += "!" + x.Label + y.Label; return x.Value != y.Value; }
    public override bool Equals(object x) { return false; }
    public override int GetHashCode() { return 0; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Number Make(string label, int value) { Trace += label; return new Number(value, label); }
    static (Number, Number, Number) Right() { Trace += "r"; return (Make("x", 1), Make("y", 9), Make("z", 3)); }
    static void Main()
    {
        bool result = (Make("a", 1), Make("b", 2), Make("c", 3)) == Right();
        Check(!result, "unequal-second-element");
        Check(Trace == "abcrxyz=ax=by", "both-operands-before-lexical-short-circuit");
        Trace = ""; var left = (new Number(1, "a"), new Number(2, "b")); var right = (new Number(1, "x"), new Number(2, "y"));
        result = left == right; Check(result, "all-elements-equal"); Check(Trace == "=ax=by", "tuple-value-components");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
