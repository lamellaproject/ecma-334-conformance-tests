/*
Rules: E12-8-16-3-identifier-target
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: private int Hidden;
Into: public int Hidden;
Csc: CS0122
*/
using System;
class Item { private int Hidden; }
class Program
{
    static void Main() { var value = new Item { Hidden = 7 }; Console.WriteLine(value != null); }
}
