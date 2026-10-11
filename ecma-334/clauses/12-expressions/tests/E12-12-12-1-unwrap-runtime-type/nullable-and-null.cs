/*
Rules: E12-12-12-1-unwrap-runtime-type; E12-12-12-1-nullable-target; E12-12-12-1-value-target; E12-12-12-1-null-literal-false; E12-12-12-1-null-value-false
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: value is int,
Into: value is long,
*/
using System;
using N = System.Nullable<int>;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? value = 3; object boxed = value;
        Check(value is int, "nullable-underlying-runtime-type");
        Check(boxed is N, "nullable-target-matches-underlying-box");
        Check(boxed is int, "unboxing-compatible-value-target");
        Check(!(boxed is long), "numeric-conversion-is-insufficient");
        value = null; Check(!(value is int), "empty-nullable-is-false");
        object missing = null; Check(!(missing is object), "null-value-is-false");
        Check(!(null is object), "null-literal-is-false");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
