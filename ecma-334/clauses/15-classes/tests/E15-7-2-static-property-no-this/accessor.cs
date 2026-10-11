/*
Rules: E15-7-2-static-property-no-this
Authority: ECMA-334 7th ed 15.7.2
Version: 7.3
Expected: reject
Mutate: static Box Owner
Into: Box Owner
*/
class Box { public static Box Owner { get { return this; } } }
class Program { static void Main() { } }
