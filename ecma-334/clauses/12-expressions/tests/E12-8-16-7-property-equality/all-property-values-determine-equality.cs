/*
Rules: E12-8-16-7-property-equality; E12-8-16-7-equals-override
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: var same = new { Count = 7, Token = new Key(19) };
Into: var same = new { Count = 7, Token = new Key(23) };
*/
using System;
class Key
{
    public int Number;
    public Key(int number) { Number = number; }
    public override bool Equals(object other) { Key value = other as Key; return value != null && value.Number == Number; }
    public override int GetHashCode() { return Number; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var first = new { Count = 7, Token = new Key(19) };
        var same = new { Count = 7, Token = new Key(19) };
        var changedFirst = new { Count = 11, Token = new Key(19) };
        var changedSecond = new { Count = 7, Token = new Key(23) };
        object boxed = first;
        Check(boxed.Equals(same), "anonymous-equality-uses-property-equals");
        Check(!boxed.Equals(changedFirst), "unequal-first-property");
        Check(!boxed.Equals(changedSecond), "unequal-second-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
