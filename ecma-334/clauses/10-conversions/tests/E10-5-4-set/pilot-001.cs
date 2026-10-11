/*
Rules: E10-5-4-set; E10-5-3-lookup-types
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Packet result=source;
Into: Packet result=default(Packet);
*/
using System;


class Parent {public int Number;public static int Calls;public static implicit operator Packet(Parent x){Calls++;return new Packet {Number=x.Number};}}
class Child:Parent {}
struct Packet {public int Number;}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child source=new Child {Number=61}; Packet result=source;
        Check(result.Number==61 && Parent.Calls==1, "E10-5-4-set-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
