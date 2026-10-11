/*
Rules: E15-6-2-5-output-argument-same-type
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: Child value;
Into: Parent value;
Csc: CS1503
*/
class Parent { }
class Child : Parent { }
class Program
{
    static void Write(out Parent value) { value = new Parent(); }
    static void Main() { Child value; Write(out value); }
}
