/*
Rules: E13-7-expression-end-reachable
Authority: ECMA-334 7th ed 13.7
Version: 7.3
Expected: reject
Mutate: Fetch();
Into: return Fetch();
*/
class Program
{
    static int Fetch() { return 6; }
    // The reachable statement end point leaves a value-returning method without a return.
    static int Read() { Fetch(); }
    static void Main() { }
}
