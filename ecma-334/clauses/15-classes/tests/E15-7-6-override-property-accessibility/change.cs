/*
Rules: E15-7-6-override-property-accessibility; E15-7-6-override-member-declared-accessibility-match
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: public override int Item
Into: protected override int Item
*/
class Base { protected virtual int Item { get { return 14; } } }
class Derived : Base { public override int Item { get { return 21; } } }
class Program { static void Main() { } }
