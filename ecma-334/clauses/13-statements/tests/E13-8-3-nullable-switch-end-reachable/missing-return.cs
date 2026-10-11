/*
Rules: E13-8-3-nullable-switch-end-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case int any: return 4;
Into: case int any: return 4; case null: return 5;
*/
class Program
{
    static int Read(int? selector) { switch (selector) { case int any: return 4; } }
    static void Main() { }
}
