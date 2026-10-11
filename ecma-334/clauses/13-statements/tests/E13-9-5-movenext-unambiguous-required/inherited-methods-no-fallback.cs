/*
Rules: E13-9-5-movenext-unambiguous-required
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: interface ICursor : ILeft, IRight { int Current { get; } }
Into: interface ICursor : ILeft, IRight { int Current { get; } new bool MoveNext(); }
*/
using System.Collections;
class Program
{
    interface ILeft { bool MoveNext(); }
    interface IRight { bool MoveNext(); }
    interface ICursor : ILeft, IRight { int Current { get; } }
    class Source : IEnumerable
    {
        public ICursor GetEnumerator() { return null; }
        IEnumerator IEnumerable.GetEnumerator() { return new int[0].GetEnumerator(); }
    }
    static void Main() { foreach (int item in new Source()) { } }
}
