/*
Rules: E8-3-12-nullable-reference-forbidden; E8-3-12-nullable-underlying-constraint
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: reject
Mutate: Nullable<string>
Into: Nullable<int>
*/
using System;
class Program { static void Main() { Nullable<string> value = default; } }
