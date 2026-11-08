/*
Rules: E12-12-13-ed3-as-reference-target
Authority: ECMA-334 3rd ed 14.9.11
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-12-13-ed3-as-reference-target/nullable-as-target.cs.part
Mutate: seed as int?
Into: seed as object
*/
// ECMA-334 3rd ed 14.9.11, p. 210 (PDF p. 230).
using System;
class Program
{
    static void Main()
    {
        int seed = 61;
        object result = seed as int?;
        if (result == (object)null) throw new Exception();
    }
}
