/*
Rules: E14-8-1-global-member-not-found
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: reject
Mutate: global::Box<int, string> value
Into: global::Box<int> value
*/
class Box<T> { }
class Program
{
    static void Main() { global::Box<int, string> value = null; }
}
