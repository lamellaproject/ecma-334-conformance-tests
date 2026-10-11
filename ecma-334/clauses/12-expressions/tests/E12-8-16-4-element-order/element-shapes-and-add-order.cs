/*
Rules: E12-8-16-4-element-order; E12-8-16-4-collection-elements; E12-8-16-4-brace-form; E12-8-16-4-trailing-comma-form; E12-8-16-4-element-list-form; E12-8-16-4-single-element-form; E12-8-16-4-braced-element-form; E12-8-16-4-expression-list-single; E12-8-16-4-expression-list-append; E12-8-16-4-add-lookup; E12-8-16-4-add-overload; E12-8-16-4-add-invocation; E12-8-16-2-collection-initializer-form; E12-8-16-2-constructor-before-initializer
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Bag { First(), { Second() }, { Third(), Fourth() }, }
Into: new Bag { (object)First(), { Second() }, { Third(), Fourth() }, }
*/
using System;
using System.Collections;
class Bag : IEnumerable
{
    public int Sum, Singles, Pairs;
    public Bag() { Program.Trace += "C"; }
    public void Add(int value) { Program.Trace += "S"; Sum += value; Singles++; }
    public void Add(object value) { Program.Trace += "O"; }
    public void Add(int first, int second) { Program.Trace += "P"; Sum += first * 100 + second; Pairs++; }
    public IEnumerator GetEnumerator() { return null; }
}
class Program
{
    public static string Trace = "";
    static int First() { Trace += "F"; return 5; }
    static int Second() { Trace += "G"; return 7; }
    static int Third() { Trace += "H"; return 11; }
    static int Fourth() { Trace += "I"; return 13; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Bag value = new Bag { First(), { Second() }, { Third(), Fourth() }, };
        Check(Trace == "CFSGSHIP", "collection-constructor-element-argument-and-add-order");
        Check(value.Singles == 2 && value.Pairs == 1, "add-overload-per-element-expression-list");
        Check(value.Sum == 1125, "every-collection-element-added");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
