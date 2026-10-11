/*
Rules: E15-6-9-partial-unimplemented-no-delegate
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: static partial void Record();
Into: static partial void Record(); static partial void Record() { }
Csc: CS0762
*/
using System;
partial class Program
{
    static partial void Record();
    static void Main() { Action action = Record; }
}
