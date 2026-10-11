/*
Rules: E15-7-3-accessor-executable-statements; E15-7-3-grammar-accessor-declarations-form-1; E15-7-3-grammar-get-accessor-declaration; E15-7-3-grammar-set-accessor-declaration; E15-7-3-grammar-accessor-body-form-1; E15-7-3-block-accessor-execution; E15-7-3-nonref-get-method-form; E15-7-3-nonref-expression-get-invocation; E15-7-3-set-method-form; E15-7-3-set-value-parameter-name; E15-7-3-set-assignment-invocation; E15-7-3-read-write-classification
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: slot = value + 3;
Into: slot = value;
*/
using System;
class Box
{
    int slot;
    public string Trace = "";
    public int Item
    {
        get { Trace += "g"; return slot; }
        set { Trace += "s"; slot = value + 3; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        box.Item = 14;
        Check(box.Trace == "s", "simple-assignment-only-setter");
        Check(box.Item == 17, "setter-value-and-getter-return");
        Check(box.Trace == "sg", "getter-in-expression");
        int sum = box.Item + box.Item;
        Check(sum == 34 && box.Trace == "sggg", "each-expression-invokes-getter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
