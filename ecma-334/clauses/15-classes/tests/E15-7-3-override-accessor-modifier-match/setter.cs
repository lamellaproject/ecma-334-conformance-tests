/*
Rules: E15-7-3-override-accessor-modifier-match
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: internal set
Into: protected set
*/
class Base { int slot; public virtual int Item { get { return slot; } protected set { slot = value; } } }
class Derived : Base { int slot; public override int Item { get { return slot; } internal set { slot = value; } } }
class Program { static void Main() { } }
