/*
Rules: E12-20-3-1-inference-error
Authority: ECMA-334 7th ed 12.20.3.1
Version: 7.3
Expected: reject
Mutate: Select<Unused, Result>
Into: Select<Result>
Csc: CS1942
*/
delegate R Selector<R>(int item);
class Source
{
    public Result Select<Unused, Result>(Selector<Result> selector) { return selector(8); }
}
class Program
{
    static void Main() { var result = from item in new Source() select item * 3; }
}
