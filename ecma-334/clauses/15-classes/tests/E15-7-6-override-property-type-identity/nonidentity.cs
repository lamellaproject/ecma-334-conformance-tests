/*
Rules: E15-7-6-override-property-type-identity
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: override string Item
Into: override object Item
*/
class Base { public virtual object Item { get { return null; } } }
class Derived : Base { public override string Item { get { return "value"; } } }
class Program { static void Main() { } }
