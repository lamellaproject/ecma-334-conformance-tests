/*
Rules: E12-6-2-1-ed5-named-arguments-trail
Authority: ECMA-334 5th ed 12.6.2.1
Version: 5
Expected: reject
Version-Witness: version-witnesses/E12-6-2-1-ed5-named-arguments-trail/in-position-name.cs.part
Mutate: Join(first: 3, 7)
Into: Join(first: 3, last: 7)
*/
class Program
{
    static int Join(int first, int last) { return first * 10 + last; }
    static void Main() { int result = Join(first: 3, 7); }
}
