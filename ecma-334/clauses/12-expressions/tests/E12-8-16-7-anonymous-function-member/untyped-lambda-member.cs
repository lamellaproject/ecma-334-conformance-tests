/*
Rules: E12-8-16-7-anonymous-function-member; E12-8-16-7-member-expression-type
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: reject
Mutate: new { Operation = () => 7 }
Into: new { Operation = (Reader)(() => 7) }
*/
delegate int Reader();
class Program
{
    static void Main() { var value = new { Operation = () => 7 }; }
}
