/*
Rules: E22-3-global-target-required
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [Mark] namespace
Into: [assembly: Mark] namespace
*/
using System;
[Mark] namespace Space { }
class MarkAttribute : Attribute { }
class Program
{
    static void Main()
    {

    }
}
