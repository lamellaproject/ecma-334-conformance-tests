/*
Rules: E22-5-3-2-conditional-no-out
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: reject
Mutate: out int value
Into: ref int value
*/
using System;
class Item { [System.Diagnostics.Conditional("X")] public static void Hit(out int value) { value = 7; } }
class Program
{
    static void Main()
    {

    }
}
