/*
Rules: E13-8-3-nullable-switch-end-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case false: return 2;
Into: case false: return 2; default: return 0;
*/
class Program
{
    static int Read(bool? flag) { switch (flag) { case true: return 1; case false: return 2; } }
    static void Main() { }
}
