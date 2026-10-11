/*
Rules: E10-2-12-identity-target; E15-2-5-interface-erasure; E15-2-5-erase-dynamic
Authority: ECMA-334 7th ed 10.2.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ICell<object> box=new Erased().Cast(source);
Into: ICell<object> box=default(ICell<object>);
*/
using System;


interface ICell<T> { T Read(); }
struct Payload:ICell<object> {public object Read(){return "seed";} }
abstract class Origin<S> {public abstract ICell<object> Cast<T>(T x) where T:S;}
class Erased:Origin<ICell<dynamic>> {public override ICell<object> Cast<T>(T x) {return x;} }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Payload source=new Payload(); ICell<object> box=new Erased().Cast(source);
        Check(box.Read().Equals("seed"), "E10-2-12-identity-target-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
