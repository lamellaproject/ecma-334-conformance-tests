/*
Rules: E8-3-12-nullable-nested-forbidden
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: reject
Mutate: Nullable<int?>
Into: Nullable<int>
*/
using System;
class Program { static void Main() { Nullable<int?> value = default; } }
