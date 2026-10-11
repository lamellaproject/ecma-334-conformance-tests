/*
Rules: E10-3-5-object; E10-3-5-downcast; E10-3-5-class-interface; E10-3-5-interface-class; E10-3-5-interface-interface; E10-3-5-null; E10-3-5-compatible; E10-3-5-failure; E10-3-1-categories
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Child child=(Child)parent;
Into: Child child=new Child();
*/
using System;

interface IOne {} interface ITwo {} class Parent {} sealed class Child:Parent,IOne,ITwo {public int Number=61;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent parent=new Child(); object box=parent; Child child=(Child)parent;
        IOne one=(IOne)parent; ITwo two=(ITwo)one; Parent again=(Parent)one; Child sealedValue=(Child)one;
        Check(ReferenceEquals(child,box) && ReferenceEquals(two,child) && ReferenceEquals(again,child) && sealedValue.Number==61, "E10-3-5-object-pilot-001-check-01");
        Parent empty=null; Check((IOne)empty==null, "E10-3-5-object-pilot-001-check-02");
        Parent bad=new Parent(); try { IOne fail=(IOne)bad; Check(false, "E10-3-5-object-pilot-001-check-03"); } catch (InvalidCastException) { Check(true, "E10-3-5-object-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-3-5-object-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
