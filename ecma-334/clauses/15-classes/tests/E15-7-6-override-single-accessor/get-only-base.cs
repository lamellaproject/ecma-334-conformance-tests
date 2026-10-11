/*
Rules: E15-7-6-override-single-accessor
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Mutate: set { }
Into: 
*/
class Base { public virtual int Item { get { return 6; } } }
class Derived : Base { public override int Item { get { return 25; } set { } } }
class Program { static void Main() { } }
