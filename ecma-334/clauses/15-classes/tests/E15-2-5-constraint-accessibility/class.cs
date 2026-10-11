/*
Rules: E15-2-5-constraint-accessibility
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: public class Box<T>
Into: internal class Box<T>
*/
internal class Root { }
public class Box<T> where T : Root { }
class Program { static void Main() { } }
