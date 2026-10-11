/*
Rules: E10-5-2-restrictions
Authority: ECMA-334 7th ed 10.5.2
Version: 7.3
Expected: reject
Mutate: static implicit operator
Into: public static implicit operator
*/
using System;

struct Packet {static implicit operator int(Packet x){return 61;}}
class Program
{
    static void Main()
    {

    }
}
