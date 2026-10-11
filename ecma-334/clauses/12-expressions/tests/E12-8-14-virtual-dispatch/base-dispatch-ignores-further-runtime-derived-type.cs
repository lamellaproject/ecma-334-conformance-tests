/*
Rules: E12-8-14-virtual-dispatch
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: base.Read()
Into: this.Read()
*/
using System;
class Root
{
    public virtual int Read() { return 1; }
    public virtual int Value { get { return 1; } }
    public virtual int this[int index] { get { return index + 1; } }
}
class Middle : Root
{
    public override int Read() { return 2; }
    public override int Value { get { return 2; } }
    public override int this[int index] { get { return index + 2; } }
}
class Leaf : Middle
{
    public override int Read() { return 3; }
    public override int Value { get { return 3; } }
    public override int this[int index] { get { return index + 3; } }
    public int FromBaseMethod() { return base.Read(); }
    public int FromBaseProperty() { return base.Value; }
    public int FromBaseIndexer() { return base[5]; }
}
class Further : Leaf
{
    public override int Read() { return 4; }
    public override int Value { get { return 4; } }
    public override int this[int index] { get { return index + 4; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Further();
        Check(leaf.FromBaseMethod() == 2, "base-method-dispatch-is-relative-to-middle");
        Check(leaf.FromBaseProperty() == 2, "base-property-dispatch-is-relative-to-middle");
        Check(leaf.FromBaseIndexer() == 7, "base-indexer-dispatch-is-relative-to-middle");
        Check(leaf.Read() == 4, "ordinary-method-dispatch-sees-further");
        Check(leaf.Value == 4, "ordinary-property-dispatch-sees-further");
        Check(leaf[5] == 9, "ordinary-indexer-dispatch-sees-further");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
