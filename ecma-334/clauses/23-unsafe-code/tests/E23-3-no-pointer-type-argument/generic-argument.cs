/*
Rules: E23-3-no-pointer-type-argument
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: Box<int*> value;
Into: Box<int> value;
*/
using System;
class Box<T> { }
class Program
{
    static void Main()
    {
        unsafe
        {
            Box<int*> value;
        }
    }
}
