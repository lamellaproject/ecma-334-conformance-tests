/*
Rules: E12-6-2-1-grammar-argument-list; E12-6-2-1-grammar-argument; E12-6-2-1-grammar-argument-name; E12-6-2-1-grammar-value; E12-6-2-1-named-definition; E12-6-2-1-positional-definition; E12-6-2-1-invocation-list; E12-6-2-1-explicit-argument-list; E12-6-2-2-position-definition; E12-6-2-2-positional-correspondence; E12-6-2-2-named-correspondence; E12-6-2-2-other-parameter-list
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Channel(7, right: 4)
Into: Channel(4, right: 7)
*/
using System;
delegate int Relay(int left, int right);
class Frame
{
    public int stamp;
    public Frame(int left, int right) { stamp = left * 10 + right; }
}
class Program
{
    static int checks, failures;
    static int Channel(int left, int right) { return left * 10 + right; }
    static void Check(bool condition, string label)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + label); }
    }
    static int Main()
    {
        Check(Channel(7, right: 4) == 74, "positional-before-named");
        Relay target = new Relay(Channel);
        Check(target(right: 6, left: 2) == 26, "delegate-names");
        Frame item = new Frame(9, right: 1);
        Check(item.stamp == 91, "constructor-names");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
