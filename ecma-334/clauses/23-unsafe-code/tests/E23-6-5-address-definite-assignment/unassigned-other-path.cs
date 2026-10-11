/*
Rules: E23-6-5-address-definite-assignment
Authority: ECMA-334 7th ed 23.6.5
Version: 7.3
Expected: reject
Mutate: if (flag)
Into: if (true)
*/
using System;
unsafe class Program
{
    static int Write(bool flag)
    {
        int value;
        if (flag)
        {
            int* pointer = &value;
            *pointer = 17;
        }
        return value;
    }
    static void Main()
    {
        Write(true);
    }
}
