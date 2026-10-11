/*
Rules: E7-5-3-inherited-private-domain; E7-5-1-outside-domain-access
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Mutate: private int hidden = 37;
Into: protected int hidden = 37;
*/
class Base { private int hidden = 37; }
class Derived : Base { public int Read() { return hidden; } }
class Program { static void Main() { new Derived().Read(); } }
