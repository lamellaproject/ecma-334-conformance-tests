/*
Rules: E23-6-5-address-no-readonly-local
Authority: ECMA-334 7th ed 23.6.5
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/foreach-variable-9801c804fe.cs.part
Mutate: int* pointer = &value;
Into: int copy = value; int* pointer = &copy;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        foreach (int value in new int[] { 13 })
        {
            int* pointer = &value;
            *pointer = 17;
            Console.WriteLine(value);
        }
    }
}
