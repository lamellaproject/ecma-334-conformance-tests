/*
Rules: E15-10-2-ed1-increment-return-containing-type
Authority: ECMA-334 1st ed 17.9.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E15-10-2-ed1-increment-return-containing-type/containing-return.cs.part
Mutate: public static Bud operator ++(Stem value)
Into: public static Stem operator ++(Stem value)
*/
// ECMA-334 1st ed 17.9.1, p. 259 (PDF p. 273), line 2. Refuse an increment operator whose
// return type is a proper derived class of its containing parameter type; the return type
// must be that containing type itself.
public class Stem
{
    public static Bud operator ++(Stem value) { return null; }
}
public class Bud : Stem { }
class Entry
{
    static void Main() { }
}
