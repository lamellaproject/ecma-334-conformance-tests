/*
Rules: E22-5-3-2-conditional-no-interface-implementation
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: reject
Mutate: [System.Diagnostics.Conditional("X")]
Into: 
*/
using System;
interface Contract { void Hit(); }
class Item : Contract { [System.Diagnostics.Conditional("X")] public void Hit() { } }
class Program
{
    static void Main()
    {

    }
}
