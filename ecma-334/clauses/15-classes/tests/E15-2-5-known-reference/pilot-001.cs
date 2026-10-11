/*
Rules: E15-2-5-known-reference
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T:ILeaf
Into: where T:class,ILeaf
*/
using System;


interface IRoot { int Read(); }
interface ILeaf : IRoot { }
interface IExtra { int Extra(); }
class Parent : IRoot { public int Read() { return 61; } }
class Child : Parent, ILeaf, IExtra { public int Extra() { return 82; } }
class Deep : Child { }
struct Stamp : ILeaf, IExtra { public int Number; public int Read(){return Number;} public int Extra(){return Number+1;} }

        static class Bridge {public static T Null<T>() where T:ILeaf {return null;} }

class Program
{
    static void Main()
    {

    }
}
