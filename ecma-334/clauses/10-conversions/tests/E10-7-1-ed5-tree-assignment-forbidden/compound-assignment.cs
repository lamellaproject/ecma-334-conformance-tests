/*
Rules: E10-7-1-ed5-tree-assignment-forbidden
Authority: ECMA-334 5th ed 11.7.1
Version: 5
Expected: reject
Mutate: (int number) => number += 7
Into: (int number) => number + 7
*/
// ECMA-334 5th ed 11.7.1, p. 106 (PDF p. 128).
using System.Linq.Expressions;
delegate int Compute(int number);
class Program
{
    static void Main()
    {
        Expression<Compute> tree = (int number) => number += 7;
    }
}
