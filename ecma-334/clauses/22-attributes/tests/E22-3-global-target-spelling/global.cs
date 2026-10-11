/*
Rules: E22-3-global-target-spelling; E22-3-global-targets-only
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [assemblies: Mark]
Into: [assembly: Mark]
*/
using System;
[assemblies: Mark] namespace Space { }
class MarkAttribute : Attribute { }
class Program
{
    static void Main()
    {

    }
}
