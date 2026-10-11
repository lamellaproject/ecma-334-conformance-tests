/*
Rules: E13-10-4-goto-case-enclosing-switch-required
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: reject
Mutate: goto case 1;
Into: return;
*/
class Program { static void Main() { goto case 1; } }
