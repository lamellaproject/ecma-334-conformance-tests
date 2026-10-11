/*
Rules: E6-4-5-7-null-untyped
Authority: ECMA-334 7th ed 6.4.5.7
Version: 7.3
Expected: reject
Mutate: var absent = null;
Into: object absent = null;
Csc: CS0815
*/
class Program
{
    static void Main() { var absent = null; }
}
