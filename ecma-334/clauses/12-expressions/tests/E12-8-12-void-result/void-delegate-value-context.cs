/*
Rules: E12-8-12-void-result
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: reject
Mutate: object result = values?[0]();
Into: values?[0]();
*/
using System;
class Program { static void Touch() { } static void Main() { Action[] values = new Action[] { Touch }; object result = values?[0](); } }
