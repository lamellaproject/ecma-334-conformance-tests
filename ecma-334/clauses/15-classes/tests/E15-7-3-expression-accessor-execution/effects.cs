/*
Rules: E15-7-3-expression-accessor-execution; E15-7-3-grammar-accessor-body-form-2
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: get => Read();
Into: get => slot;
*/
using System;
class Box
{
    int slot;
    public string Trace = "";
    int Read() { Trace += "r"; return slot; }
    void Write(int amount) { Trace += "w"; slot = amount; }
    public int Item { get => Read(); set => Write(value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); box.Item = 38;
        Check(box.Trace == "w", "expression-setter");
        Check(box.Item == 38 && box.Trace == "wr", "expression-getter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
