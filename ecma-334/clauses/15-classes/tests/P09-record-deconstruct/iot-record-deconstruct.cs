/*
Rules: P09-record-deconstruct
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: record Panel(int Width, int Height) { public int Height { get; set; } = Height; }
Into: record Panel(int Width, int Height) { public int Height { get; set; } = Height; public void Deconstruct(out int Width, out int Height) { Width = this.Height; Height = this.Width; } }
*/
using System;
record Panel(int Width, int Height) { public int Height { get; set; } = Height; }
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
        Panel p = new Panel(7, 19);
        int w, h;
        p.Deconstruct(out w, out h);
        Check(w == 7 && h == 19, "parameter-order");
        p.Height = 26;
        p.Deconstruct(out w, out h);
        Check(w == 7 && h == 26, "current-property-values");
        (int width, int height) = p;
        Check(width == 7 && height == 26, "deconstruction-use");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
