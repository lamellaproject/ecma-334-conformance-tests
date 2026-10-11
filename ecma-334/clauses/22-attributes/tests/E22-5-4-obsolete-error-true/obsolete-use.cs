/*
Rules: E22-5-4-obsolete-error-true
Authority: ECMA-334 7th ed 22.5.4
Version: 7.3
Expected: reject
Mutate: [Obsolete("retired", true)]
Into: [Obsolete("retired", false)]
*/
using System;
class Item { [Obsolete("retired", true)] public static int Old() { return 7; } }
class Program
{
    static void Main()
    {
        int x = Item.Old();
    }
}
