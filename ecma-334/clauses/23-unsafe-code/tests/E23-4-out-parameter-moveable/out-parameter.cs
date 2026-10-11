/*
Rules: E23-4-out-parameter-moveable
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
    static void Write(out int value)
    {
        value = 17;
        int* p = &value;
    }
    static void Main()
    {
        int local;
        Write(out local);
    }
}
