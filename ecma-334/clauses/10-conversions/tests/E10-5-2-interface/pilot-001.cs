/*
Rules: E10-5-2-interface
Authority: ECMA-334 7th ed 10.5.2
Version: 7.3
Expected: reject
Mutate: interface IMarker {}
Into: class IMarker {}
*/
using System;

interface IMarker {} struct Packet {public static implicit operator IMarker(Packet x){return null;}}
class Program
{
    static void Main()
    {

    }
}
