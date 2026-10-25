/*
Rules: P08-verbatim-alternate-prefix; E12-8-3-argument-order; E12-8-3-positive-alignment; E12-8-3-nonpositive-alignment
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: @$"[{Take(1),3}][{Take(2),-4}]"
Into: @"[{Take(1),3}][{Take(2),-4}]"
*/
using System;
class Program
{
    static int checks, failures, trace;
    static string Take(int mark) { trace = trace * 10 + mark; return mark == 1 ? "oak" : "elm"; }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string text = @$"[{Take(1),3}][{Take(2),-4}]";
        Check(text == "[oak][elm ]", "alignment-result");
        Check(trace == 12, "holes-left-to-right-once");
        string padded = @$"<{"fir",5}>";
        Check(padded == "<  fir>", "positive-padding");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
