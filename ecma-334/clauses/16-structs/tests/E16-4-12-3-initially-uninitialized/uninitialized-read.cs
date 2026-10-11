/*
Rules: E16-4-12-3-initially-uninitialized
Authority: ECMA-334 7th ed 16.4.12.3
Version: 7.3
Expected: reject
Mutate: Span<int> item;
Into: Span<int> item = default(Span<int>);
*/
using System;
class Program { static void Main() { Span<int> item; int length = item.Length; } }
