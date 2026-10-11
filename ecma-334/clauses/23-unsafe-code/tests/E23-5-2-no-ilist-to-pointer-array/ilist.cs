/*
Rules: E23-5-2-no-ilist-to-pointer-array
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: reject
Mutate: int*[] items = (int*[])view;
Into: int[] items = (int[])view;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        System.Collections.Generic.IList<int> view = null;
        int*[] items = (int*[])view;
    }
}
