/*
Rules: E15-2-5-ed3-delegate-constraint-forbidden
Authority: ECMA-334 3rd ed 25.7
Version: ISO-2
Expected: reject
Mutate: where T : System.Delegate
Into: where T : class
*/
class Requirement<T> where T : System.Delegate { }
class Program
{
    static void Main() { }
}
