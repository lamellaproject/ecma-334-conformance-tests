/*
Rules: E10-7-1-ed5-tree-dynamic-forbidden
Authority: ECMA-334 5th ed 11.7.1
Version: 5
Expected: reject
Mutate: ((dynamic)item).Read()
Into: ((Receiver)item).Read()
*/
// ECMA-334 5th ed 11.7.1, p. 106 (PDF p. 128).
using System.Linq.Expressions;
public class Receiver { public int Read() { return 31; } }
delegate int Compute(object item);
class Program
{
    static void Main()
    {
        Expression<Compute> tree = item => ((dynamic)item).Read();
    }
}
