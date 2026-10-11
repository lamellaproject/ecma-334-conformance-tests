/*
Rules: E15-2-4-2-generic-attribute-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Stamp<T> : RootAttribute
Into: class Stamp : RootAttribute
*/
class RootAttribute : System.Attribute { }
class Stamp<T> : RootAttribute { }
class Program { static void Main() { } }
