/*
Rules: E15-3-2-instance-type-scope
Authority: ECMA-334 7th ed 15.3.2
Version: 7.3
Expected: reject
Mutate: static Cell<T> Value;
Into: static Cell<int> Value;
*/
class Cell<T> { }
class Program
{
    static Cell<T> Value;
    static void Main() { }
}
