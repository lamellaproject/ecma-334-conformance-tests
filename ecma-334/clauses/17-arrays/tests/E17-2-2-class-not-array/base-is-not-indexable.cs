/*
Rules: E17-2-2-class-not-array
Authority: ECMA-334 7th ed 17.2.2
Version: 7.3
Expected: reject
Mutate: erased[0]
Into: ((int[])erased)[0]
*/
using System;
class Program
{
    static void Main()
    {
        Array erased = new int[1];
        int item = erased[0];
    }
}
