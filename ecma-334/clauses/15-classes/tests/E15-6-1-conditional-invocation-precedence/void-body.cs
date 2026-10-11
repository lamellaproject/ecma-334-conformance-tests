/*
Rules: E15-6-1-conditional-invocation-precedence; E15-6-1-grammar-method-body-form-2; E15-6-1-expression-body-execution
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public void Touch(Counter target) => target?.Next();
Into: public void Touch(Counter target) => target.Next();
*/
using System;
class Counter
{
    public int Calls;
    public int Next() { return ++Calls; }
}
class Caller { public void Touch(Counter target) => target?.Next(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Caller caller = new Caller();
        Counter target = new Counter();
        caller.Touch(null);
        Check(target.Calls == 0, "void-conditional-invocation-skips-null-target");
        caller.Touch(target);
        Check(target.Calls == 1, "void-conditional-invocation-discards-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
