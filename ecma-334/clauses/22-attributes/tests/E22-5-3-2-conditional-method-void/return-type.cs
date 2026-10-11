/*
Rules: E22-5-3-2-conditional-method-void
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: reject
Mutate: static int Hit() { return 7; }
Into: static void Hit() { }
*/
using System;
class Item { [System.Diagnostics.Conditional("X")] public static int Hit() { return 7; } }
class Program
{
    static void Main()
    {

    }
}
