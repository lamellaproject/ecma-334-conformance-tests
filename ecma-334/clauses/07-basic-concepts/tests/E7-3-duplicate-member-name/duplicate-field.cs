/*
Rules: E7-3-duplicate-member-name
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: public string Member;
Into: public string Different;
*/
class Holder { public int Member; public string Member; }
class Program { static void Main() { } }
