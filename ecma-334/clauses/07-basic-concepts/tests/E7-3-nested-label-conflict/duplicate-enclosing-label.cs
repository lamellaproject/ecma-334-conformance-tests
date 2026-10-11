/*
Rules: E7-3-nested-label-conflict
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: target:;
Into: renamed:;
*/
class Program
{
    static void Main() { target: { target:; } }
}
