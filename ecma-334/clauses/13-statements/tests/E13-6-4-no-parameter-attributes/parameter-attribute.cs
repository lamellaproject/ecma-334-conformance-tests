/*
Rules: E13-6-4-no-parameter-attributes
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: Local([Marker] int value)
Into: Local(int value)
*/
using System;
class MarkerAttribute : Attribute { }
class Program { static void Main() { void Local([Marker] int value) { } } }
