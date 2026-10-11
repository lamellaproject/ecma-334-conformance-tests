/*
Rules: E15-7-5-accessor-modifier-no-member-lookup-effect; E15-7-5-property-modifiers-determine-binding
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: reject
Mutate: private get
Into: get
*/
class Base { public int Item { get { return 9; } } }
class Derived : Base { int slot; public new int Item { private get { return slot; } set { slot = value; } } }
class Program { static void Main() { Derived box = new Derived(); int seen = box.Item; } }
