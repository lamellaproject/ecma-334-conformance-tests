/*
Rules: E12-14-3-or-left-evaluation
Authority: ECMA-334 7th ed 12.14.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Signal result = source || Right();
Into: Signal result = (Signal)source || Right();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    class Trunk { }
    class Twig : Trunk { }
    struct Signal
    {
        public int Mark;
        public static int ImplicitCalls, ExplicitCalls;
        public Signal(int mark) { Mark = mark; }
        public static implicit operator Signal(Trunk source) { ImplicitCalls++; return new Signal(17); }
        public static explicit operator Signal(Twig source) { ExplicitCalls++; return new Signal(41); }
        public static bool operator true(Signal source) { return true; }
        public static bool operator false(Signal source) { return true; }
        public static Signal operator &(Signal left, Signal right) { return left; }
        public static Signal operator |(Signal left, Signal right) { return left; }
    }
    static int RightCalls;
    static Signal Right() { RightCalls++; return new Signal(5); }
    static int Main()
    {
        Twig source = new Twig();
        Signal result = source || Right();
        Check(result.Mark == 17, "implicit-left-or");
        Check(Signal.ImplicitCalls == 1 && Signal.ExplicitCalls == 0 && RightCalls == 0, "left-conversion-once-or");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
