/*
Rules: E10-2-9-variant-interface; E10-3-7-variant-interface
Authority: ECMA-334 7th ed 10.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: IOut<object> boxed=value;
Into: IOut<object> boxed=default(IOut<object>);
*/
using System;

interface IOut<out T> { T Read(); } struct Producer:IOut<string> {public string Read(){return "seed";}}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Producer value=new Producer(); IOut<object> boxed=value;
        Producer copy=(Producer)boxed;
        Check(boxed.Read().Equals("seed") && copy.Read()=="seed", "E10-2-9-variant-interface-pilot-001-check-01");
        IOut<string> narrow=value; Producer reverse=(Producer)narrow;
        Check(reverse.Read()=="seed", "E10-2-9-variant-interface-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
