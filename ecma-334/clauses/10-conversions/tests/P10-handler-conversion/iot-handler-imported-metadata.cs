/*
Rules: P10-handler-conversion; P10-handler-arguments; P10-handler-result
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Fixture: {"libraries":[{"name":"HandlerLibrary","units":[{"source":"self","defines":["LIBRARY"]}]}],"program":{"references":[{"library":"HandlerLibrary"}]}}
Mutate: Sink.Read(6, $"a{4}")
Into: Sink.Read(6, $"aa{4}")
*/
using System;
using System.Runtime.CompilerServices;
#if LIBRARY
[InterpolatedStringHandler]
public struct Imported
{
    public int Length, Holes, Context, Number;
    public Imported(int length, int holes, int context) { Length = length; Holes = holes; Context = context; Number = 0; }
    public void AppendLiteral(string text) { }
    public void AppendFormatted(int value) { Number = value; }
}
public class Sink
{
    public static Imported Read(int context, [InterpolatedStringHandlerArgument("context")] Imported item) { return item; }
}
#else
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Imported item = Sink.Read(6, $"a{4}");
        Check(item.Length == 1 && item.Holes == 1, "metadata-handler-recognized");
        Check(item.Context == 6, "metadata-context-attribute");
        Check(item.Number == 4, "metadata-append-lookup");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
#endif
