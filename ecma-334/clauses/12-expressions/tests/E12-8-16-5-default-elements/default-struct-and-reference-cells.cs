/*
Rules: E12-8-16-5-default-elements
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: State[] cells = new State[2];
Into: State[] cells = new State[2] { new State(7), new State(19) };
*/
using System;
struct State
{
    public static int Calls;
    public int Number;
    public object Link;
    public State(int number) { Calls++; Number = number; Link = new object(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        State[] cells = new State[2];
        object[] links = new object[2];
        bool defaults = cells[0].Number == 0 && cells[1].Number == 0 && cells[0].Link == null && cells[1].Link == null;
        Check(defaults, "struct-cells-have-default-fields");
        Check(State.Calls == 0, "array-does-not-call-element-constructor");
        Check(links[0] == null && links[1] == null, "reference-cells-default-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
