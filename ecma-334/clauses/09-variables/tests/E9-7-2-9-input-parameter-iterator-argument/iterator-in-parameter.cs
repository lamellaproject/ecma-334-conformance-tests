/*
Rules: E9-7-2-9-input-parameter-iterator-argument
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: Values(in int cell)
Into: Values(int cell)
Csc: CS1623
*/
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> Values(in int cell) { yield return cell; }
    static void Main() { }
}
