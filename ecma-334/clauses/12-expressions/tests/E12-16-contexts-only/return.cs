/*
Rules: E12-16-contexts-only
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: reject
Mutate: return throw new System.Exception();
Into: return true ? throw new System.Exception() : 3;
*/
class Program { static int Run() { return throw new System.Exception(); } static void Main() { } }
