/*
Rules: E17-3-no-system-array-instance; E17-2-2-abstract-base
Authority: ECMA-334 7th ed 17.3
Version: 7.3
Expected: reject
Mutate: new Array()
Into: new int[1]
*/
using System;
class Program
{
    static void Main() { Array values = new Array(); }
}
