/*
Rules: E22-5-5-4-caller-member-type-restriction
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: reject
Mutate: int member = 0
Into: string member = null
*/
using System;
class Item { public static void Hit([System.Runtime.CompilerServices.CallerMemberName] int member = 0) { } }
class Program
{
    static void Main()
    {

    }
}
