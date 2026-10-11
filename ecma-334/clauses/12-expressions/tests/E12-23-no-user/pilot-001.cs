/*
Rules: E12-23-no-user
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: int destination=(int)new Packet();
Into: int destination=default(int);
Csc: CS0133
*/
using System;

struct Packet { public static implicit operator int(Packet p) { return 61; } }
class Program
{
    static void Main()
    {
        const int destination=(int)new Packet();
    }
}
