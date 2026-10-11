/*
Rules: E10-5-4-target-ambiguous
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: reject
Mutate: int result=source;
Into: int result=default(int);
Csc: CS0457
*/
using System;


struct Packet {public static implicit operator short(Packet x){return 61;} public static implicit operator ushort(Packet x){return 62;}}

class Program
{
    static void Main()
    {
        Packet source=new Packet(); int result=source;
    }
}
