/*
Rules: E15-3-8-instance-access-type; E15-3-8-instance-access-receiver
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: Register.Touch()
Into: new Register().Touch()
*/
class Register { public void Touch() { } }
class Program { static void Main() { Register.Touch(); } }
