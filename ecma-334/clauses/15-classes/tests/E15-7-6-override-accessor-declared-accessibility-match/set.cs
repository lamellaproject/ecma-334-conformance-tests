/*
Rules: E15-7-6-override-accessor-declared-accessibility-match
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: private set
Into: protected set
*/
class Base { int slot; public virtual int Item { get { return slot; } protected set { slot = value; } } }
class Derived : Base { int slot; public override int Item { get { return slot; } private set { slot = value; } } }
class Program { static void Main() { } }
