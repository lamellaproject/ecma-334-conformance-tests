/*
Rules: E12-8-16-7-member-expression-type
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: reject
Mutate: new { Operation = Work }
Into: new { Operation = (Reader)Work }
*/
delegate int Reader();
class Program
{
    static int Work() { return 7; }
    static void Main() { var value = new { Operation = Work }; }
}
