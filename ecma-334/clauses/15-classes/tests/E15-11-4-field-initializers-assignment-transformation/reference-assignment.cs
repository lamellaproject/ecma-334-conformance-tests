/*
Rules: E15-11-4-field-initializers-assignment-transformation
Authority: ECMA-334 7th ed 15.11.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public readonly Token Item = Factory.Create();
Into: public readonly Token Item;
*/
using System;
class Token { public int N = 13; }
class Factory
{
    public static Token Last;
    public static Token Create() { Last = new Token(); return Last; }
}
abstract class Basis
{
    public Token Observed;
    public Basis() { Observed = Read(); }
    protected abstract Token Read();
}
class Gauge : Basis
{
    public readonly Token Item = Factory.Create();
    protected override Token Read() { return Item; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.Item != null && item.Item.N == 13, "initializer-assigned-reference-value");
        Check(object.ReferenceEquals(item.Item, Factory.Last), "initializer-assigned-result-identity");
        Check(object.ReferenceEquals(item.Item, item.Observed), "base-observed-stored-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
