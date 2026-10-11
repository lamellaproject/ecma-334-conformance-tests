/*
Rules: E7-8-1-invalid-qualified-name; E7-8-1-qualified-class-struct-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: private class Fruit { }
Into: public class Fruit { }
Csc: CS0122
*/
class Orchard { private class Fruit { } }
class Program { static void Main() { Orchard.Fruit item = null; } }
