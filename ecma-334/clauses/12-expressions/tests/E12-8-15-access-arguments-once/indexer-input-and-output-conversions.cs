/*
Rules: E12-8-15-access-arguments-once; E12-8-15-access-receiver-once; E12-8-15-access-get; E12-8-15-access-get-save; E12-8-15-access-input-conversion; E12-8-15-access-operator-call; E12-8-15-access-output-conversion; E12-8-15-access-set; E12-8-15-access-old-result
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: Receiver()[First(), Second()]--
Into: --Receiver()[First(), Second()]
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
    public int Gets, Sets, GetFirst, GetSecond, SetFirst, SetSecond;
    public Cell(int value) { Value = new Token(value); }
    public Token this[int first, int second]
    {
        get { Program.trace += "G"; Gets++; GetFirst = first; GetSecond = second; return Value; }
        set { Program.trace += "S"; Sets++; SetFirst = first; SetSecond = second; Value = value; }
    }
}
class Program
{
    public static string trace = "";
    static int checks, failures, receivers, firstArguments, secondArguments;
    static Cell first = new Cell(8), second = new Cell(20);
    static Cell Receiver() { trace += "R"; return receivers++ == 0 ? first : second; }
    static int First() { trace += "A"; return ++firstArguments + 1; }
    static int Second() { trace += "B"; return ++secondArguments + 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token before = Receiver()[First(), Second()]--;
        Check(trace == "RABGIOS", "indexer-receiver-arguments-get-input-output-set-order");
        Check(before.Value == 8, "indexer-postfix-result-is-saved-getter-value");
        Check(first.Value.Value == 7, "indexer-setter-receives-converted-result");
        Check(second.Value.Value == 20, "indexer-setter-reuses-initial-receiver");
        Check(receivers == 1, "indexer-receiver-evaluated-once");
        Check(firstArguments == 1 && secondArguments == 1, "indexer-arguments-evaluated-once");
        Check(first.GetFirst == 2 && first.GetSecond == 3, "getter-receives-evaluated-arguments");
        Check(first.SetFirst == 2 && first.SetSecond == 3 && first.Gets == 1 && first.Sets == 1, "setter-reuses-arguments-and-accessors-called-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
