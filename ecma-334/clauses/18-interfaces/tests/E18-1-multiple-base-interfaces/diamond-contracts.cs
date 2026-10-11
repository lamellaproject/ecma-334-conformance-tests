/*
Rules: E18-1-multiple-base-interfaces; E18-1-multiple-implementations; E18-2-4-explicit-base-definition; E18-2-4-base-form; E18-2-4-base-transitive-closure; E18-2-4-inherits-members; E18-2-4-implements-base-interfaces; E18-3-body-defines-members
Authority: ECMA-334 7th ed 18.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: interface IBundle : ILeft, IRight
Into: interface IBundle : ILeft
*/
using System;
interface IRoot { int Root(); }
interface ILeft : IRoot { int Left(); }
interface IRight : IRoot { int Right(); }
interface IBundle : ILeft, IRight { int Own(); }
interface ILabel { int Label(); }
class Bundle : IBundle, ILabel
{
    public int Root() { return 2; }
    public int Left() { return 3; }
    public int Right() { return 5; }
    public int Own() { return 7; }
    public int Label() { return 11; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IBundle value = new Bundle();
        IRoot root = value;
        ILabel label = (ILabel)value;
        Check(root.Root() == 2, "transitive-root");
        Check(value.Left() == 3, "first-base-member");
        Check(value.Right() == 5, "second-base-member");
        Check(value.Own() == 7, "declared-member");
        Check(label.Label() == 11, "second-direct-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
