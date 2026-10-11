/*
Rules: E12-8-22-method-type-arguments
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: reject
Mutate: nameof(Work<int>)
Into: nameof(Work)
*/
class Program
{
    static void Work<T>() { }
    static void Main() { string name = nameof(Work<int>); }
}
