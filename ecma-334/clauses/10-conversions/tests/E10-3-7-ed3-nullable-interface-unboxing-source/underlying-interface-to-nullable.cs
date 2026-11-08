/*
Rules: E10-3-7-ed3-nullable-interface-unboxing-source
Authority: ECMA-334 3rd ed 13.2.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-3-7-ed3-nullable-interface-unboxing-source/underlying-interface-to-nullable.cs.part
Mutate: (Seal?)boxed
Into: (Seal)boxed
*/
// ECMA-334 3rd ed 13.2.4, p. 139 (PDF p. 159).
using System;
interface IFacet { }
struct Seal : IFacet { }
class Program
{
    static void Main()
    {
        IFacet boxed = new Seal();
        object result = (Seal?)boxed;
        if (result == (object)null) throw new Exception();
    }
}
