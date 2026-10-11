/*
Rules: E8-3-3-default-constructor-declaration; E8-3-3-default-constructor-zero-initialization; E8-3-3-default-constructor-new; E8-3-3-struct-value-field-default; E8-3-3-struct-reference-field-default
Authority: ECMA-334 7th ed 8.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: State value = new State();
Into: State value = new State(9);
*/
using System;
struct State { public int Number; public bool Flag; public object Next; public State(int number) { Number = number; Flag = true; Next = new object(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        State value = new State();
        Check(value.Number == 0 && !value.Flag && value.Next == null, "zero-initialized-struct-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
