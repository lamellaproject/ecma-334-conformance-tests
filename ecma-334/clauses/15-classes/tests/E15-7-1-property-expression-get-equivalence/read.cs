/*
Rules: E15-7-1-property-expression-get-equivalence; E15-7-1-grammar-property-body-form-2
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Expression => Take();
Into: Expression => 18;
*/
using System;
class Meter
{
    public int Calls;
    int Take() { Calls++; return Calls + 17; }
    public int Expression => Take();
    public int Block { get { return Take(); } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Meter left = new Meter(), right = new Meter();
        Check(left.Expression == 18 && right.Block == 18, "expression-result");
        Check(left.Calls == 1 && right.Calls == 1, "one-evaluation");
        Check(left.Expression == 19 && right.Block == 19, "reevaluate-on-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
