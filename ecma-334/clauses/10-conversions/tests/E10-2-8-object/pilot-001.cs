/*
Rules: E10-2-8-object; E10-2-8-base; E10-2-8-implemented; E10-2-8-interface-base; E10-2-8-no-runtime-check; E10-2-8-identity-preserved; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Parent parent=child;
Into: Parent parent=new Parent();
*/
using System;

interface IRoot { int Read(); } interface IChild:IRoot {} class Parent {} class Child:Parent,IChild { public int Read() { return 61; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child child=new Child(); Parent parent=child; IChild fine=child; IRoot root=fine;
        object token=child; dynamic dyn=child; object round=dyn;
        Check(ReferenceEquals(parent,child) && ReferenceEquals(root,child) && root.Read()==61 && ReferenceEquals(token,round), "E10-2-8-object-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
