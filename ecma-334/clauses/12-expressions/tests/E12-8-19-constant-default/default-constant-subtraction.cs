/*
Rules: E12-8-19-constant-default; E12-8-19-constant-context
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: reject
Mutate: const uint Wrapped = 0u - 1u;
Into: const uint Wrapped = unchecked(0u - 1u);
Csc: CS0220
*/
using System;
class Program
{
    const uint Wrapped = 0u - 1u;
    static void Main() { Console.WriteLine(Wrapped); }
}
