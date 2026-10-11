/*
Rules: E8-4-5-type-parameters-not-inherited
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: reject
Mutate: public T Value;
Into: public int Value;
*/
class Base<T> { }
class Derived : Base<int> { public T Value; }
class Program { static void Main() { } }
