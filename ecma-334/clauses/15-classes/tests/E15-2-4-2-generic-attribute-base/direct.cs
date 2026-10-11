/*
Rules: E15-2-4-2-generic-attribute-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Stamp<T> : System.Attribute
Into: class Stamp : System.Attribute
*/
class Stamp<T> : System.Attribute { }
class Program { static void Main() { } }
