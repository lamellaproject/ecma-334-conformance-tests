/*
Rules: E12-8-16-7-null-literal-member; E12-8-16-7-member-expression-type
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: reject
Mutate: new { Link = null }
Into: new { Link = (object)null }
*/
class Program
{
    static void Main() { var value = new { Link = null }; }
}
