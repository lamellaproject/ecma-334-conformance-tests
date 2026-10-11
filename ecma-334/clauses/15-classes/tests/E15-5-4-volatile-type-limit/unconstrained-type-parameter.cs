/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: reject
Mutate: public volatile T Value;
Into: public T Value;
Csc: CS0677
*/
class Holder<T> { public volatile T Value; }
class Program { static void Main() { new Holder<int>().Value = 307; } }
