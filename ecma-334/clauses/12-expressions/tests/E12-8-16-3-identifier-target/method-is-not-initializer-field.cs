/*
Rules: E12-8-16-3-identifier-target
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: new Item { Touch = 3 }
Into: new Item { Number = 3 }
Csc: CS1913
*/
using System;
class Item { public int Number; public void Touch() { } }
class Program
{
    static void Main() { var value = new Item { Touch = 3 }; Console.WriteLine(value != null); }
}
