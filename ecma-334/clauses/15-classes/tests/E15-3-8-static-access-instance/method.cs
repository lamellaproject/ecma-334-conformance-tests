/*
Rules: E15-3-8-static-access-instance; E15-3-8-static-access-type
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: new Register().Touch()
Into: Register.Touch()
*/
class Register { public static void Touch() { } }
class Program { static void Main() { new Register().Touch(); } }
