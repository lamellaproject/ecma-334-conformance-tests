/*
Rules: E19-4-containing-type-accessibility; E19-3-class-modifier-meaning
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: reject
Mutate: private enum Code
Into: public enum Code
*/
class Holder { private enum Code { Mark } }
class Program { static void Main() { int value = (int)Holder.Code.Mark; } }
