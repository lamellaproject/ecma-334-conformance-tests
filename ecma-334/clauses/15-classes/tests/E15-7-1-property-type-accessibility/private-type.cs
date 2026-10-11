/*
Rules: E15-7-1-property-type-accessibility
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: public Hidden Item
Into: private Hidden Item
Csc: CS0053
*/
public class Box { private class Hidden { } public Hidden Item { get { return null; } } }
class Program { static void Main() { } }
