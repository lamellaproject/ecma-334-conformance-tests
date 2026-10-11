/*
Rules: E23-4-in-parameter-moveable
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: reject
Mutate: int* p = &value;
Into: fixed (int* p = &value) { }
Csc: CS0212
*/
using System;
unsafe class Program
{
    static void Read(in int value)
    {
        int* p = &value;
    }
    static void Main()
    {
        int local = 11;
        Read(in local);
    }
}
