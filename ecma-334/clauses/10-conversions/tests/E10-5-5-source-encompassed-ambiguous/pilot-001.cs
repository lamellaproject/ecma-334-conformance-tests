/*
Rules: E10-5-5-source-encompassed-ambiguous
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: reject
Mutate: Packet result=(Packet)input;
Into: Packet result=default(Packet);
Csc: CS0457
*/
using System;

struct Packet {public static explicit operator Packet(short x){return new Packet();} public static explicit operator Packet(ushort x){return new Packet();}}
class Program
{
    static void Main()
    {
        long input=61; Packet result=(Packet)input;
    }
}
