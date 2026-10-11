/*
Rules: E12-8-16-2-value-default-result; E12-8-16-2-value-default-invocation; E12-8-16-2-value-default-type
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: State value = new State();
Into: State value = new State(7);
*/
using System;
enum Mode { Idle = 0, Active = 1 }
struct State
{
    public int Number;
    public object Link;
    public State(int number) { Number = number; Link = new object(); }
}
class Program
{
    static int Choose(State value) { return 1; }
    static int Choose(object value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        State value = new State();
        Check(value.Number == 0 && value.Link == null, "default-struct-fields");
        Check(new Mode() == Mode.Idle, "default-enum-value");
        Check(new int() == 0 && !new bool(), "default-simple-values");
        Check(Choose(new State()) == 1, "default-creation-static-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
