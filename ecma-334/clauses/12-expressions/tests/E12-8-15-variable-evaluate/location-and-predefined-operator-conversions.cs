/*
Rules: E12-8-15-variable-evaluate; E12-8-15-variable-save; E12-8-15-variable-input-conversion; E12-8-15-variable-operator-call; E12-8-15-variable-output-conversion; E12-8-15-variable-store; E12-8-15-variable-old-result
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: Receiver()[Index()]++
Into: ++Receiver()[Index()]
*/
using System;
struct Token
{
    public int Value;
    public Token(int value) { Value = value; }
    public static implicit operator int(Token value) { Program.trace += "I"; return value.Value; }
    public static implicit operator Token(int value) { Program.trace += "O"; return new Token(value); }
}
class Program
{
    public static string trace = "";
    static int checks, failures, receivers, indices;
    static Token[] first = { new Token(6), new Token(10) };
    static Token[] second = { new Token(40), new Token(50) };
    static Token[] Receiver() { trace += "R"; return receivers++ == 0 ? first : second; }
    static int Index() { trace += "A"; return indices++ == 0 ? 0 : 1; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token before = Receiver()[Index()]++;
        Check(trace == "RAIO", "variable-location-before-input-and-output-conversions");
        Check(before.Value == 6, "postfix-saves-original-variable-value");
        Check(first[0].Value == 7, "converted-result-stored-in-selected-location");
        Check(first[1].Value == 10, "other-index-remains-intact");
        Check(second[0].Value == 40 && second[1].Value == 50, "other-receiver-remains-intact");
        Check(receivers == 1, "variable-receiver-evaluated-once");
        Check(indices == 1, "variable-index-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
