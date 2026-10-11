/*
Rules: E20-2-value-declaration-form; E20-2-nongeneric-header; E20-2-declared-name; E20-2-returns-by-value; E20-2-parameters; E20-2-value-result-type; E20-1-delegate-class-base; E20-2-reference-type; E20-5-creation-expression; E20-1-static-callable-entity; E20-5-static-target; E20-5-single-method-entry; E20-1-nonempty-invocation-list; E20-6-single-invocation; E20-6-single-return-value
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: new Joiner(Join)
Into: new Joiner(Reverse)
*/
using System;
class MarkAttribute : Attribute { }
[Mark] public delegate int Joiner(int left, int right);
class Program
{
    static int checks, failures;
    static int calls, savedLeft, savedRight;
    static int Join(int left, int right) { calls++; savedLeft = left; savedRight = right; return left * 10 + right; }
    static int Reverse(int left, int right) { calls++; savedLeft = right; savedRight = left; return right * 10 + left; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Joiner join = new Joiner(Join);
        Joiner alias = join;
        Delegate baseValue = join;
        Check(join(4, 7) == 47, "by-value-result");
        Check(calls == 1 && savedLeft == 4 && savedRight == 7, "single-target-arguments");
        Check((object)join == (object)alias, "delegate-reference-alias");
        Check(baseValue == join && join.Target == null, "static-method-and-delegate-base");
        Check(join.GetInvocationList().Length == 1, "single-nonempty-invocation-list");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
