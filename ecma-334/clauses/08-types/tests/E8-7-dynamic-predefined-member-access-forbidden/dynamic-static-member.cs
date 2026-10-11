/*
Rules: E8-7-dynamic-predefined-member-access-forbidden
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: dynamic.Equals(null, null)
Into: object.Equals(null, null)
*/
class Program { static void Main() { bool value = dynamic.Equals(null, null); } }
