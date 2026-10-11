/*
Rules: E15-6-2-2-value-argument-conversion
Authority: ECMA-334 7th ed 15.6.2.2
Version: 7.3
Expected: reject
Mutate: Holder.Touch(new Parent())
Into: Holder.Touch(new Child())
Csc: CS1503
*/
class Parent { }
class Child : Parent { }
class Holder { public static void Touch(Child value) { } }
class Program { static void Main() { Holder.Touch(new Parent()); } }
