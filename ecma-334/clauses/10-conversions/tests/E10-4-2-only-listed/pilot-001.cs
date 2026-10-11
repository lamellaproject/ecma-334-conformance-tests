/*
Rules: E10-4-2-only-listed
Authority: ECMA-334 7th ed 10.4.2
Version: 7.3
Expected: reject
Mutate: Packet result=()=>61;
Into: Packet result=default(Packet);
Csc: CS1660
*/
using System;

struct Packet {public static implicit operator Packet(Func<int> x){return new Packet();}}
class Program
{
    static void Main()
    {
        Packet result=()=>61;
    }
}
