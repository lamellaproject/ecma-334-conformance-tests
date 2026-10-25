/*
Rules: P08-verbatim-alternate-prefix; E12-8-3-formattable; E12-8-3-argument-order
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 5
Mutate: @$"entry:{Mark()}
Into: @"entry:{Mark()}
*/
using System;
class Program
{
    static int checks, failures, calls;
    static string Mark() { calls++; return "birch"; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string text = @$"entry:{Mark()}
exit";
        Check(text == "entry:birch\nexit", "multiline-lf");
        Check(calls == 1, "multiline-hole-once");
        object token = new object();
        FormattableString form = @$"item {token} / {"ash",-5}";
        Check(form.ArgumentCount == 2, "formattable-count");
        Check(object.ReferenceEquals(form.GetArgument(0), token), "formattable-identity");
        Check(form.ToString() == "item System.Object / ash  ", "formattable-render");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
