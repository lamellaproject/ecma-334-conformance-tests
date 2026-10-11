/*
Rules: E15-2-5-base-struct; E15-2-5-base-enum; E15-2-5-base-delegate; E15-2-5-base-array; E15-2-5-base-substitution
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: ValueType v=x;
Into: ValueType v=default(Stamp);
*/
using System;


interface IRoot { int Read(); }
interface ILeaf : IRoot { }
interface IExtra { int Extra(); }
class Parent : IRoot { public int Read() { return 61; } }
class Child : Parent, ILeaf, IExtra { public int Extra() { return 82; } }
class Deep : Child { }
struct Stamp : ILeaf, IExtra { public int Number; public int Read(){return Number;} public int Extra(){return Number+1;} }

        enum Label {Seed=61}
        abstract class Origin<S> {public abstract int Read<T>(T x) where T:S;}
        class StructOrigin:Origin<Stamp> {public override int Read<T>(T x) {ValueType v=x; return ((Stamp)(object)v).Number;} }
        class EnumOrigin:Origin<Label> {public override int Read<T>(T x) {Enum e=x; return (int)(Label)(object)e;} }
        class DelegateOrigin:Origin<Func<int>> {public override int Read<T>(T x) {Func<int> f=x; return f();} }
        class ArrayOrigin:Origin<int[]> {public override int Read<T>(T x) {Array a=x; return a.Length;} }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new StructOrigin().Read(new Stamp {Number=61})==61, "E15-2-5-base-struct-pilot-001-check-01");
        Check(new EnumOrigin().Read(Label.Seed)==61, "E15-2-5-base-struct-pilot-001-check-02");
        Check(new DelegateOrigin().Read<Func<int>>(()=>61)==61, "E15-2-5-base-struct-pilot-001-check-03");
        Check(new ArrayOrigin().Read(new int[]{4,5,6})==3, "E15-2-5-base-struct-pilot-001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
