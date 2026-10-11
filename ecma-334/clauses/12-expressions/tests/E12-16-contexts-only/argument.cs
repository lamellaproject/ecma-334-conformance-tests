/*
Rules: E12-16-contexts-only
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: reject
Mutate: Use(throw new System.Exception())
Into: Use(true ? throw new System.Exception() : 3)
*/
class Program { static void Use(int value) { } static void Main() { Use(throw new System.Exception()); } }
