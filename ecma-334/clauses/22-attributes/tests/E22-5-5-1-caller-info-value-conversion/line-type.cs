/*
Rules: E22-5-5-1-caller-info-value-conversion; E22-5-5-2-caller-line-type-restriction
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: reject
Mutate: byte line = 0
Into: int line = 0
*/
using System;
class Item { public static void Hit([System.Runtime.CompilerServices.CallerLineNumber] byte line = 0) { } }
class Program
{
    static void Main()
    {

    }
}
