/*
Rules: E12-10-1-dynamic-binding; E12-10-1-dynamic-result-type; E12-10-1-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.10.1
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: left * right
Into: left + right
*/
using System;
public class Answer { public int Value; public Answer(int v) { Value = v; } }
public class Number
{
    public int Value;
    public static Answer operator *(Number x, Number y) { return new Answer(x.Value * y.Value); }
    public static Answer operator /(Number x, Number y) { return new Answer(x.Value / y.Value); }
    public static Answer operator %(Number x, Number y) { return new Answer(x.Value % y.Value); }
    public static Answer operator +(Number x, Number y) { return new Answer(x.Value + y.Value); }
    public static Answer operator -(Number x, Number y) { return new Answer(x.Value - y.Value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(Answer a) { return 1; }
    static int Pick(object a) { return 2; }
    static void Main()
    {
        dynamic left = new Number { Value = 19 }; Number right = new Number { Value = 4 };
        var product = left * right;
        Check(product.Value == 76, "runtime-product");
        Check((left / right).Value == 4, "runtime-quotient");
        Check((left % right).Value == 3, "runtime-remainder");
        Check((left + right).Value == 23, "runtime-sum");
        Check((left - right).Value == 15, "runtime-difference");
        Check(Pick(product) == 1, "result-remains-dynamic");
        left = 21; dynamic divisor = 4; Check(left / divisor == 5, "runtime-types-change-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
