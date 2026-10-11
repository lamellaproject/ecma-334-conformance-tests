/*
Rules: E10-4-3-no-arbitrary-explicit; E10-5-5-empty
Authority: ECMA-334 7th ed 10.4.3
Version: 7.3
Expected: reject
Mutate: Packet result=(Packet)source;
Into: Packet result=default(Packet);
Csc: CS0030
*/
using System;

struct Packet {public static explicit operator Packet(decimal x){return new Packet();}}
class Program
{
    static void Main()
    {
        double source=61; Packet result=(Packet)source;
    }
}
