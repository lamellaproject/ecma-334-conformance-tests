/*
Rules: E7-1-entry-exactly-one
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: class Second { static void Main() { } }
Into: class Second { static void Start() { } }
*/
class First { static void Main() { } }
class Second { static void Main() { } }
