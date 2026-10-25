/*
Rules: E15-10-2-ed1-decrement-return-containing-type
Authority: ECMA-334 1st ed 17.9.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E15-10-2-ed1-decrement-return-containing-type/containing-return.cs.part
Mutate: public static Tip operator --(Branch value)
Into: public static Branch operator --(Branch value)
*/
// ECMA-334 1st ed 17.9.1, p. 259 (PDF p. 273), line 2. Refuse an decrement operator whose
// return type is a proper derived class of its containing parameter type; the return type
// must be that containing type itself.
public class Branch
{
    public static Tip operator --(Branch value) { return null; }
}
public class Tip : Branch { }
class Entry
{
    static void Main() { }
}
