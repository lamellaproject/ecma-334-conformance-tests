/*
Rules: E13-10-2-break-enclosing-statement-required
Authority: ECMA-334 7th ed 13.10.2
Version: 7.3
Expected: reject
Mutate: break;
Into: return;
*/
class Program { static void Main() { break; } }
