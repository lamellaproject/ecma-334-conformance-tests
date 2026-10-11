/*
Rules: E15-3-2-generic-instance-type; E15-3-2-this-instance-type
Authority: ECMA-334 7th ed 15.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public Pair<T, U> Self() { return this; }
Into: public Pair<U, T> Self() { return this; }
*/
using System;
class Pair<T, U>
{
    public T First;
    public U Second;
    public Pair<T, U> Self() { return this; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair<int, string> value = new Pair<int, string>();
        value.First = 257;
        value.Second = "pair";
        Pair<int, string> same = value.Self();
        Check((object)same == (object)value, "generic-this-has-corresponding-parameter-arguments");
        Check(same.First == 257 && same.Second == "pair", "instance-type-preserves-parameter-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
