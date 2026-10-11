/*
Rules: E10-5-4-empty
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: reject
Mutate: Packet result=value;
Into: Packet result=default(Packet);
Csc: CS0266
*/
using System;

struct Packet {public static implicit operator Packet(byte x){return new Packet();}}
class Program
{
    static void Main()
    {
        int value=61; Packet result=value;
    }
}
