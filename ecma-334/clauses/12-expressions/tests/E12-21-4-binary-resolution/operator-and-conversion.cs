/*
Rules: E12-21-4-binary-resolution; E12-21-4-implicit-result-assignment
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: value += Right()
Into: value *= Right()
*/
using System;
struct Number
{
    public int Value;
    public Number(int value) { Value = value; }
    public static Intermediate operator +(Number left, int right) { Program.trace += "O"; return new Intermediate(left.Value + right); }
}
struct Intermediate
{
    public int Value;
    public Intermediate(int value) { Value = value; }
    public static implicit operator Number(Intermediate value) { Program.trace += "C"; return new Number(value.Value * 2); }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Right() { trace += "R"; return 14; }
    static bool IsNumber(Number value) { return true; }
    static bool IsNumber(Intermediate value) { return false; }
    static void Main()
    {
        Number value = new Number(5);
        var result = (value += Right());
        Check(value.Value == 38 && result.Value == 38, "operator-result-implicitly-converted");
        Check(IsNumber(result), "compound-result-type");
        Check(trace == "ROC", "binary-operator-before-result-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
