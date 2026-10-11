/*
Rules: E12-8-15-access-receiver-once; E12-8-15-access-get; E12-8-15-access-get-save; E12-8-15-access-input-conversion; E12-8-15-access-operator-call; E12-8-15-access-output-conversion; E12-8-15-access-set; E12-8-15-access-old-result
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: Receiver().Slot++
Into: ++Receiver().Slot
*/
using System;
struct Token
{
    public int Value;
    public Token(int value) { Value = value; }
    public static implicit operator int(Token value) { Program.trace += "I"; return value.Value; }
    public static implicit operator Token(int value) { Program.trace += "O"; return new Token(value); }
}
class Cell
{
    public Token Value;
    public int Gets, Sets;
    public Cell(int value) { Value = new Token(value); }
    public Token Slot
    {
        get { Program.trace += "G"; Gets++; return Value; }
        set { Program.trace += "S"; Sets++; Value = value; }
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures, receivers;
    static Cell first = new Cell(6), second = new Cell(20);
    static Cell Receiver() { trace += "R"; return receivers++ == 0 ? first : second; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token before = Receiver().Slot++;
        Check(trace == "RGIOS", "property-get-input-output-set-order");
        Check(before.Value == 6, "property-postfix-result-is-saved-getter-value");
        Check(first.Value.Value == 7, "property-setter-receives-converted-result");
        Check(second.Value.Value == 20, "property-setter-reuses-initial-receiver");
        Check(receivers == 1, "property-receiver-evaluated-once");
        Check(first.Gets == 1 && first.Sets == 1, "property-accessors-each-called-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
