/*
Rules: E7-1-entry-partial-implementation
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: static partial void Main();
Into: static void Main() { }
*/
partial class Program
{
    static partial void Main();
}
