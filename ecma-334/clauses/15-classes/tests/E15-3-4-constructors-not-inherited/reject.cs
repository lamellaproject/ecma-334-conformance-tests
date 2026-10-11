/*
Rules: E15-3-4-constructors-not-inherited
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: reject
Mutate: new Child(317)
Into: new Parent(317)
*/
class Parent { public Parent(int value) { } }
class Child : Parent { public Child() : base(0) { } }
class Program { static void Main() { new Child(317); } }
