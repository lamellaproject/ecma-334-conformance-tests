/*
Rules: E12-12-9-distinct-delegate-types
Authority: ECMA-334 7th ed 12.12.9
Version: 7.3
Expected: reject
Mutate: left == right
Into: (System.Delegate)left == right
*/
delegate void Left();
delegate void Right();
class Program
{
    static void M() { }
    static void Main() { Left left = M; Right right = M; bool b = left == right; }
}
