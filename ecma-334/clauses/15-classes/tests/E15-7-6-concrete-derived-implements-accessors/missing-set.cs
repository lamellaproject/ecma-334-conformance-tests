/*
Rules: E15-7-6-concrete-derived-implements-accessors
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: get { return 25; }
Into: get { return 25; } set { }
*/
abstract class Base { public abstract int Item { get; set; } }
class Derived : Base { public override int Item { get { return 25; } } }
class Program { static void Main() { } }
