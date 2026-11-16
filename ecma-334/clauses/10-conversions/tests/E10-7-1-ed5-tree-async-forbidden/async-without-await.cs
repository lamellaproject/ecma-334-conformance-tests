/*
Rules: E10-7-1-ed5-tree-async-forbidden
Authority: ECMA-334 5th ed 11.7.1
Version: 5
Expected: reject
Mutate: Expression<Compute> tree = async
Into: Compute tree = async
*/
// ECMA-334 5th ed 11.7.1, p. 106 (PDF p. 128).
using System.Linq.Expressions;
using System.Threading.Tasks;

delegate Task<int> Compute(int number);
class Program
{
    static void Main()
    {
        Expression<Compute> tree = async (int number) => number * 3;
    }
}
