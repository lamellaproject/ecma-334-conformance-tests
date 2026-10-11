/*
Rules: E13-8-2-if-branch-end-reachable
Authority: ECMA-334 7th ed 13.8.2
Version: 7.3
Expected: reject
Mutate: else { }
Into: else return 8;
*/
class Program
{
    static int Read(bool flag) { if (flag) return 3; else { } }
    static void Main() { }
}
