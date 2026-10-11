/*
Rules: E23-5-2-no-explicit-array-to-ilist-base
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: reject
Mutate: System.Collections.Generic.IEnumerable<int> view = (System.Collections.Generic.IEnumerable<int>)items;
Into: System.Collections.IEnumerable view = items;
*/
using System;
class Program
{
    static unsafe void Main()
    {
        int*[] items = new int*[1];
        System.Collections.Generic.IEnumerable<int> view = (System.Collections.Generic.IEnumerable<int>)items;
    }
}
