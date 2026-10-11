/*
Rules: E10-5-5-target-encompassing-ambiguous
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: reject
Mutate: byte result=(byte)source;
Into: byte result=default(byte);
Csc: CS0457
*/
using System;

struct Packet {public static explicit operator short(Packet x){return 61;} public static explicit operator ushort(Packet x){return 62;}}
class Program
{
    static void Main()
    {
        Packet source=new Packet(); byte result=(byte)source;
    }
}
