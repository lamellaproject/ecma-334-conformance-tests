/*
Rules: P10-struct-constructor-array-bypass; E16-4-5-value-field-default
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: Token[] values = new Token[3];
Into: Token[] values = new Token[] { new Token(), new Token(), new Token() };
*/
using System;
readonly record struct Token
{
    public static int Calls;
    public readonly int Code;
    public Token() { Calls++; Code = 67; }
}
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Token[] values = new Token[3];
        Check(values[0].Code == 0, "array-first-zeroed");
        Check(values[1].Code == 0, "array-middle-zeroed");
        Check(values[2].Code == 0, "array-last-zeroed");
        Check(Token.Calls == 0, "array-no-element-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
