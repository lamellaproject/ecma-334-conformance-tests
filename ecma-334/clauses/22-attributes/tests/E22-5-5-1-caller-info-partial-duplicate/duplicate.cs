/*
Rules: E22-5-5-1-caller-info-partial-duplicate
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: reject
Mutate: static partial void Hit([System.Runtime.CompilerServices.CallerMemberName] string name)
Into: static partial void Hit(string name)
*/
using System;
partial class Item
{
    static partial void Hit([System.Runtime.CompilerServices.CallerMemberName] string name = null);
    static partial void Hit([System.Runtime.CompilerServices.CallerMemberName] string name) { }
}
class Program
{
    static void Main()
    {

    }
}
