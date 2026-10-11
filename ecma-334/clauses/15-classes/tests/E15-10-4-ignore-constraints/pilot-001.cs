/*
Rules: E15-10-4-ignore-constraints; E15-10-4-generic-collision; E15-10-4-predefined-implicit; E15-10-4-predefined-explicit; E15-10-4-interface-ignore; E15-10-4-implicit-considered; E10-5-4-identity-once; E10-5-5-identity-once
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Parent<Child> up=source;
Into: Parent<Child> up=default(Parent<Child>);
*/
using System;


interface IMarker {}
class Parent<T>:IMarker {
    public static int Calls;
    public static implicit operator Parent<T>(T x){Calls++;return new Parent<T>();}
    public static implicit operator T(Parent<T> x){Calls++;return (T)(object)new Child();}
}
class Child:Parent<Child> {}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child source=new Child(); Parent<Child> up=source;
        Check(ReferenceEquals(source,up) && Parent<Child>.Calls==0, "E15-10-4-ignore-constraints-pilot-001-check-01");
        Child cast=(Child)up;
        Check(ReferenceEquals(cast,source) && Parent<Child>.Calls==0, "E15-10-4-ignore-constraints-pilot-001-check-02");
        Child implicitDown=up;
        Check(implicitDown!=null && !ReferenceEquals(implicitDown,source) && Parent<Child>.Calls==1, "E15-10-4-ignore-constraints-pilot-001-check-03");
        Parent<IMarker> other=new Parent<IMarker>(); IMarker view=(IMarker)other;
        Check(ReferenceEquals(other,view) && Parent<IMarker>.Calls==0, "E15-10-4-ignore-constraints-pilot-001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
