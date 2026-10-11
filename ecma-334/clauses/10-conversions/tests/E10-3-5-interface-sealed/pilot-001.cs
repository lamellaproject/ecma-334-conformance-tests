/*
Rules: E10-3-5-interface-sealed
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: reject
Mutate: Sealed target=(Sealed)source;
Into: Sealed target=default(Sealed);
Csc: CS0030
*/
using System;

sealed class Sealed {} interface IMarker {}
class Program
{
    static void Main()
    {
        IMarker source=null; Sealed target=(Sealed)source;
    }
}
