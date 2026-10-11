/*
Rules: E12-8-20-explicit-default-value; E12-8-20-explicit-default-form; E12-8-20-explicit-syntax
Authority: ECMA-334 7th ed 12.8.20
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: State value = default(State);
Into: State value = new State(11);
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
        State value = default(State);
        Check(value.Number == 0 && value.Link == null, "explicit-struct-default-fields");
        Check(State.Calls == 0, "explicit-default-does-not-call-user-constructor");
        Check(default(string) == null && !default(int?).HasValue, "explicit-reference-and-nullable-defaults");
        Check(default(int) == 0 && !default(bool), "explicit-simple-type-defaults");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
