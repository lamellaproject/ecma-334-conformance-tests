/*
Rules: E10-5-5-target-encompassed-ambiguous
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: reject
Mutate: long result=(long)source;
Into: long result=default(long);
Csc: CS0457
*/
using System;

struct Packet {public static explicit operator short(Packet x){return 61;} public static explicit operator ushort(Packet x){return 62;}}
class Program
{
    static void Main()
    {
        Packet source=new Packet(); long result=(long)source;
    }
}
