/*
Rules: E15-10-4-ignore-constraints; E15-10-4-implicit-considered
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Child result=source;
Into: Child result=default(Child);
*/
using System;


class Holder<T> where T:Holder<T> {
    public static int Calls;public static implicit operator T(Holder<T> x){Calls++;return (T)(object)new Child();}
}
class Child:Holder<Child> {}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child child=new Child(); Holder<Child> source=child; Child result=source;
        Check(result!=null && !ReferenceEquals(result,child) && Holder<Child>.Calls==1, "E15-10-4-ignore-constraints-pilot-002-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
