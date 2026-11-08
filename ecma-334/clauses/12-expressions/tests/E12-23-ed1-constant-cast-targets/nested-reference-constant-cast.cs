/*
Rules: E12-23-ed1-constant-cast-targets
Authority: ECMA-334 1st ed 14.15
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E12-23-ed1-constant-cast-targets/nested-reference-constant-cast.cs.part
Mutate: (object)(string)null
Into: null
*/
// ECMA-334 1st ed 14.15, p. 177 (PDF p. 191).
using System;
class ConstantTarget
{
    const object Missing = (object)(string)null;
    static int Main()
    {
        if ((object)Missing != (object)null) return 1;
        Console.WriteLine("OK 1");
        return 0;
    }
}
