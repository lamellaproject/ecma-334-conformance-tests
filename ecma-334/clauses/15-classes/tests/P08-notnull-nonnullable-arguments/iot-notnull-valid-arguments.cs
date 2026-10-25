/*
Rules: P08-notnull-nonnullable-arguments
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: Token<string> word = new Token<string>(41);
Into: Token<string?> word = new Token<string?>(41);
*/
#nullable enable
using System;
class Token<T> where T : notnull
{
    public int Value;
    public Token(int value) { Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Token<string> word = new Token<string>(41);
        Token<int> number = new Token<int>(29);
        Check(word.Value == 41, "notnull-reference-argument");
        Check(number.Value == 29, "notnull-value-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
