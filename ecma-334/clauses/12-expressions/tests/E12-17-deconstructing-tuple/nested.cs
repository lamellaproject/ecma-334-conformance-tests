/*
Rules: E12-17-deconstructing-tuple; E12-17-infer-deconstruction-type; E12-17-var-form; E12-17-explicit-type-form; E12-17-explicit-variable-type; E12-17-explicit-expression-type; E12-17-implicit-classification; E12-17-explicit-classification
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (int number, (var text, long wide))
Into: (int number, (var wide, long text))
*/
using System;
class Program
{
    static int calls;
    static (int, (string, long)) Make() { calls++; return (23, ("word", 29L)); }
    static int Kind(int x) { return 1; } static int Kind(string x) { return 2; } static int Kind(long x) { return 3; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        (int number, (var text, long wide)) = Make();
        Check(number == 23 && text == "word" && wide == 29L && calls == 1 && Kind(number) == 1 && Kind(text) == 2 && Kind(wide) == 3, "nested-declaration-elements-and-inferred-types");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
