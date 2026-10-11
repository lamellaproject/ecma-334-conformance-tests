/*
Rules: E22-5-5-3-caller-file-type-restriction
Authority: ECMA-334 7th ed 22.5.5.3
Version: 7.3
Expected: reject
Mutate: int file = 0
Into: string file = null
*/
using System;
class Item { public static void Hit([System.Runtime.CompilerServices.CallerFilePath] int file = 0) { } }
class Program
{
    static void Main()
    {

    }
}
