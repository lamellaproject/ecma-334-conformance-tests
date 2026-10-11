/*
Rules: E15-2-4-2-base-accessibility
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: internal class Root
Into: public class Root
*/
internal class Root { }
public class Leaf : Root { }
class Program { static void Main() { } }
