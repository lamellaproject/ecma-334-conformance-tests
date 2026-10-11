/*
Rules: E12-8-15-access-operator-call; E12-8-15-access-get-save; E12-8-15-access-old-result; E12-8-15-access-set
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Receiver().Slot++
Into: ++Receiver().Slot
*/
using System;
class Number
{
    public int Value;
    public Number(int value) { Value = value; }
    public static Number operator++(Number value) { Program.trace += "P"; Program.seen = value; return new Number(value.Value + 4); }
}
class Cell
{
    public Number Value = new Number(6);
    public Number Slot
    {
        get { Program.trace += "G"; return Value; }
        set { Program.trace += "S"; Value = value; }
    }
}
class Program
{
    public static string trace = "";
    public static Number seen;
    static int checks, failures;
    static Cell cell = new Cell();
    static Cell Receiver() { trace += "R"; return cell; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Number original = cell.Value;
        Number before = Receiver().Slot++;
        Check(trace == "RGPS", "property-get-operator-set-order");
        Check(object.ReferenceEquals(seen, original), "operator-receives-saved-getter-result");
        Check(object.ReferenceEquals(before, original), "postfix-returns-saved-getter-reference");
        Check(cell.Value.Value == 10, "setter-stores-user-operator-return");
        Check(!object.ReferenceEquals(cell.Value, original), "setter-stores-new-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
