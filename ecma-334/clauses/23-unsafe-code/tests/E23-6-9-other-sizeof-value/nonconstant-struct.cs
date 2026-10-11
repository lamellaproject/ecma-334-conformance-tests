/*
Rules: E23-6-9-other-sizeof-value
Authority: ECMA-334 7th ed 23.6.9
Version: 7.3
Expected: reject
Mutate: const int total = sizeof(Item);
Into: int total = sizeof(Item);
*/
using System;
struct Item { public byte Small; public int Wide; }
class Program
{
    static unsafe void Main()
    {
        const int total = sizeof(Item);
    }
}
