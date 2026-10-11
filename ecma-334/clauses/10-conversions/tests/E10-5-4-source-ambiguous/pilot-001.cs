/*
Rules: E10-5-4-source-ambiguous
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: reject
Mutate: Packet result=source;
Into: Packet result=default(Packet);
Csc: CS0457
*/
using System;


struct Packet {public static implicit operator Packet(short x){return new Packet();} public static implicit operator Packet(ushort x){return new Packet();}}

class Program
{
    static void Main()
    {
        byte source=61; Packet result=source;
    }
}
