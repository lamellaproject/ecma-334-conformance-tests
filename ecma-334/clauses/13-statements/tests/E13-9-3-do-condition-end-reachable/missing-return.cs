/*
Rules: E13-9-3-do-condition-end-reachable
Authority: ECMA-334 7th ed 13.9.3
Version: 7.3
Expected: reject
Mutate: while (false);
Into: while (true);
*/
class Program
{
    static int Read() { do { } while (false); }
    static void Main() { }
}
