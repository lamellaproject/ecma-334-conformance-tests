/*
Rules: E7-5-3-constructed-type-domain; E7-5-5-field-type-accessibility
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Mutate: internal class Box<T>
Into: public class Box<T>
*/
internal class Box<T> { }
public class Api { public Box<int> Value; }
class Program { static void Main() { } }
