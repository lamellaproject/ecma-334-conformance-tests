/*
Rules: E10-3-5-sealed-interface
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: reject
Mutate: IMarker target=(IMarker)source;
Into: IMarker target=default(IMarker);
Csc: CS0030
*/
using System;

sealed class Sealed {} interface IMarker {}
class Program
{
    static void Main()
    {
        Sealed source=new Sealed(); IMarker target=(IMarker)source;
    }
}
