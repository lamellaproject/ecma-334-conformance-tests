/*
Rules: E7-5-3-constructed-type-domain; E7-5-5-field-type-accessibility
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Mutate: internal class Hidden
Into: public class Hidden
*/
internal class Hidden { }
public class Box<T, U> { }
public class Api
{
    public Box<Hidden, int> First;
    public Box<int, Hidden> Second;
}
class Program { static void Main() { } }
