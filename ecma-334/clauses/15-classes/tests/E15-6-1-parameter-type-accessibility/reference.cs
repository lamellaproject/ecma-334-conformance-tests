/*
Rules: E15-6-1-parameter-type-accessibility
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public void Touch(ref Hidden value)
Into: internal void Touch(ref Hidden value)
Csc: CS0051
*/
class Hidden { }
public class Holder { public void Touch(ref Hidden value) { } }
class Program { static void Main() { } }
