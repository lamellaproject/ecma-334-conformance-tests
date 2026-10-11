/*
Rules: E22-2-2-usage-target-restriction
Authority: ECMA-334 7th ed 22.2.2
Version: 7.3
Expected: reject
Mutate: AttributeTargets.Method
Into: AttributeTargets.Class
*/
using System;
[AttributeUsage(AttributeTargets.Method)] class MarkAttribute : Attribute { }
[Mark] class Item { }
class Program
{
    static void Main()
    {

    }
}
