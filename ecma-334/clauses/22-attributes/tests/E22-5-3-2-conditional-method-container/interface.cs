/*
Rules: E22-5-3-2-conditional-method-container
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: reject
Mutate: [System.Diagnostics.Conditional("X")]
Into: 
*/
using System;
interface Contract { [System.Diagnostics.Conditional("X")] void Hit(); }
class Program
{
    static void Main()
    {

    }
}
