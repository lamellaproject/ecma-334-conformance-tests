/*
Rules: E23-4-ref-parameter-moveable
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
    static void Write(ref int value)
    {
        int* p = &value;
    }
    static void Main()
    {
        int local = 13;
        Write(ref local);
    }
}
