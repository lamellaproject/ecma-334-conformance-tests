/*
Rules: E23-5-2-foreach-temporaries-hidden
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: reject
Mutate: int index = i0;
Into: int index = 0;
Csc: CS0103
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int*[,] items = new int*[1, 1];
        foreach (int* current in items)
        {
            int index = i0;
        }
    }
}
