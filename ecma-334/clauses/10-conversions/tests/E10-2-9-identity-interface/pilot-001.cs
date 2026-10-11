/*
Rules: E10-2-9-identity-interface; E10-3-7-identity-interface
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ICell<dynamic> box=source;
Into: ICell<dynamic> box=default(ICell<dynamic>);
*/
using System;

interface ICell<T> { T Read(); } struct Payload:ICell<object> { public object Read(){return "seed";} }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Payload source=new Payload(); ICell<dynamic> box=source; ICell<object> erased=box;
        Payload restored=(Payload)erased;
        Check(erased.Read().Equals("seed") && restored.Read().Equals("seed") && ReferenceEquals(box,erased), "E10-2-9-identity-interface-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
