/*
Rules: E15-6-2-4-reference-argument-same-type
Authority: ECMA-334 7th ed 15.6.2.4
Version: 7.3
Expected: reject
Mutate: Child value = new Child();
Into: Parent value = new Child();
Csc: CS1503
*/
class Parent { }
class Child : Parent { }
class Program
{
    static Parent Read(ref Parent value) { return value; }
    static void Main() { Child value = new Child(); Read(ref value); }
}
