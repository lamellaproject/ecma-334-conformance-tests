/*
Rules: E15-2-5-ed3-enum-constraint-forbidden
Authority: ECMA-334 3rd ed 25.7
Version: ISO-2
Expected: reject
Mutate: where T : System.Enum
Into: where T : class
*/
class Requirement<T> where T : System.Enum { }
class Program
{
    static void Main() { }
}
