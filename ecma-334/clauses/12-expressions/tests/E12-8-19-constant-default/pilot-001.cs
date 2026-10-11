/*
Rules: E12-8-19-constant-default
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: reject
Mutate: byte value=(byte)256;
Into: byte value=default(byte);
Csc: CS0221
*/
using System;


class Program
{
    static void Main()
    {
        const byte value=(byte)256;
    }
}
