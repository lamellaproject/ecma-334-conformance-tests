/*
Rules: E7-5-3-type-text-definition; E7-5-3-private-domain
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: [Archive.Label] class Archive
Into: [Archive.Label] class Outside { } class Archive
*/
using System;
[Archive.Label] class Archive
{
    private sealed class LabelAttribute : Attribute { }
}
class Program
{
    static void Main()
    {
        // Access to the private attribute type in this declaration is the observation.
        Console.WriteLine("OK 0");
    }
}
