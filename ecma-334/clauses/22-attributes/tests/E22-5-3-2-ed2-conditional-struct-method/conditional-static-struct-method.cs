/*
Rules: E22-5-3-2-ed2-conditional-struct-method
Authority: ECMA-334 2nd ed 24.4.2
Version: ISO-1
Expected: run
Stdout: OK 2
Mutate: Conditional("TELEGRAM")
Into: Conditional("SILENT_TELEGRAM")
*/
#define TELEGRAM
using System;
class MessageTotal
{
    public static int Value;
}
struct Transmitter
{
    [System.Diagnostics.Conditional("TELEGRAM")]
    public static void Send(int value) { MessageTotal.Value += value; }
}
class StaticConditional
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    static int Main()
    {
        Transmitter.Send(13);
        Check(MessageTotal.Value == 13, "static-conditional-first-call");
        Transmitter.Send(8);
        Check(MessageTotal.Value == 21, "static-conditional-second-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
