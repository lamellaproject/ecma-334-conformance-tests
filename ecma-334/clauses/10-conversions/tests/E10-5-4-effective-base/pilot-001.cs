/*
Rules: E10-5-4-effective-base; E10-5-5-effective-base
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Packet implicitValue=Bridge.Implicit(source);
Into: Packet implicitValue=default(Packet);
*/
using System;


class Parent {public int Number;public static int Calls;public static implicit operator Packet(Parent x){Calls++;return new Packet {Number=x.Number};}}
class Child:Parent {} struct Packet {public int Number;}
struct Input {public int Number;}
class TargetBase {public int Number;public static explicit operator TargetBase(Input x){return new Target {Number=x.Number};}}
class Target:TargetBase {}
static class Bridge {
    public static Packet Implicit<T>(T x) where T:Parent {return x;}
    public static Packet Explicit<T>(T x) where T:Parent {return (Packet)x;}
    public static T ToTarget<T>(Input x) where T:TargetBase {return (T)x;}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child source=new Child {Number=61}; Packet implicitValue=Bridge.Implicit(source); Packet explicitValue=Bridge.Explicit(source);
        Target result=Bridge.ToTarget<Target>(new Input {Number=82});
        Check(implicitValue.Number==61 && explicitValue.Number==61 && Parent.Calls==2 && result.Number==82, "E10-5-4-effective-base-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
