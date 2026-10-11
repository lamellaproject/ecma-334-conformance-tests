/*
Rules: E23-7-no-captured-local-variable
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: &value
Into: &cells[0]
Csc: CS1686; CS0213
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int value = 7;
        int[] cells = new int[1];
        Action use = () => Console.WriteLine(value);
        fixed (int* pointer = &value) { }
        use();
    }
}
