/*
Rules: E10-5-2-different
Authority: ECMA-334 7th ed 10.5.2
Version: 7.3
Expected: reject
Mutate: operator Packet?(Packet x){return x;}
Into: operator long(Packet x){return 0L;}
*/
using System;

struct Packet {public static implicit operator Packet?(Packet x){return x;}}
class Program
{
    static void Main()
    {

    }
}
