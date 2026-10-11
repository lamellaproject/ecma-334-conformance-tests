/*
Rules: E18-2-3-3-invariance; E18-2-3-1-invariant
Authority: ECMA-334 7th ed 18.2.3.3
Version: 7.3
Expected: reject
Mutate: IBox<object> destination = source
Into: IBox<string> destination = source
Csc: CS0266
*/
interface IBox<T> { }
class Box : IBox<string> { }
class Program
{
    static void Main() { IBox<string> source = new Box(); IBox<object> destination = source; }
}
