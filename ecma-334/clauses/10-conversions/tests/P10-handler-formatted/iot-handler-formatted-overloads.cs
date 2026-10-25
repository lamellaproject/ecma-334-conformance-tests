/*
Rules: P10-handler-formatted
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 5
Mutate: Capture item = $"{Read(1)}{Read(2),-7}{Read(3):seed}{Read(4),9:leaf}";
Into: Capture item = $"{Read(1)}{Read(2),-6}{Read(3):seed}{Read(4),9:leaf}";
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public string Kinds;
    public int Values, Left, Right;
    public string FirstFormat, SecondFormat;
    public Capture(int length, int holes) { Kinds = ""; Values = Left = Right = 0; FirstFormat = SecondFormat = ""; }
    public void AppendFormatted(int value) { Kinds += "A"; Values = Values * 10 + value; }
    public void AppendFormatted(int value, int alignment) { Kinds += "B"; Values = Values * 10 + value; Left = alignment; }
    public void AppendFormatted(int value, string format) { Kinds += "C"; Values = Values * 10 + value; FirstFormat = format; }
    public void AppendFormatted(int value, int alignment, string format) { Kinds += "D"; Values = Values * 10 + value; Right = alignment; SecondFormat = format; }
}
class Program
{
    static int checks, failures, reads;
    static int Read(int value) { reads = reads * 10 + value; return value; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Capture item = $"{Read(1)}{Read(2),-7}{Read(3):seed}{Read(4),9:leaf}";
        Check(item.Kinds == "ABCD", "shape-overloads");
        Check(item.Values == 1234 && reads == 1234, "value-order-once");
        Check(item.Left == -7 && item.Right == 9, "alignment-arguments");
        Check(item.FirstFormat == "seed", "format-only-argument");
        Check(item.SecondFormat == "leaf", "combined-format-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
