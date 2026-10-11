/*
Rules: E15-10-4-duplicate-signature
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: explicit operator int
Into: explicit operator long
*/
using System;

struct Packet {public static implicit operator int(Packet x){return 61;} public static explicit operator int(Packet x){return 62;}}
class Program
{
    static void Main()
    {

    }
}
