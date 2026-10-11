/*
Rules: E22-5-5-2-caller-line-type-restriction
Authority: ECMA-334 7th ed 22.5.5.2
Version: 7.3
Expected: reject
Mutate: int line)
Into: int line = 0)
*/
using System;
class Item { public static void Hit([System.Runtime.CompilerServices.CallerLineNumber] int line) { } }
class Program
{
    static void Main()
    {

    }
}
