/*
Rules: E13-3-1-iterator-safe-context
Authority: ECMA-334 7th ed 13.3.1
Version: 7.3
Expected: reject
Mutate: int* pointer = null;
Into: int value = 0;
*/
using System.Collections.Generic;
unsafe class Program
{
    static IEnumerable<int> Values() { int* pointer = null; yield return 6; }
    static void Main() { }
}
