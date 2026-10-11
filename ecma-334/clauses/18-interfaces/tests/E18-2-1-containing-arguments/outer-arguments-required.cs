/*
Rules: E18-2-1-containing-arguments
Authority: ECMA-334 7th ed 18.2.1
Version: 7.3
Expected: reject
Mutate: Shelf.IRead item
Into: Shelf<int>.IRead item
*/
class Shelf<T> { public interface IRead { } }
class Reader : Shelf<int>.IRead { }
class Program { static void Main() { Shelf.IRead item = new Reader(); } }
