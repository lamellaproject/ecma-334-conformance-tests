/*
Rules: E22-5-3-2-conditional-no-delegate
Authority: ECMA-334 7th ed 22.5.3.2
Version: 7.3
Expected: reject
Mutate: Work action = Item.Hit;
Into: Work action = Item.Ordinary;
*/
using System;
delegate void Work();
class Item { [System.Diagnostics.Conditional("X")] public static void Hit() { } public static void Ordinary() { } }
class Program
{
    static void Main()
    {
        Work action = Item.Hit;
    }
}
