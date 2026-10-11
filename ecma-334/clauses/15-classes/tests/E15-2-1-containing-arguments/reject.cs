/*
Rules: E15-2-1-containing-arguments
Authority: ECMA-334 7th ed 15.2.1
Version: 7.3
Expected: reject
Mutate: Crate.Item item;
Into: Crate<int>.Item item;
*/
class Crate<T> { public class Item { } }
class Program
{
    static Crate.Item item;
    static void Main() { }
}
