/*
Rules: E19-3-duplicate-modifier
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: reject
Mutate: public public enum Code
Into: public enum Code
*/
public public enum Code { Mark }
class Program { static void Main() { } }
