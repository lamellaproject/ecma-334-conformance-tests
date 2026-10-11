/*
Rules: E15-6-2-1-default-conversion
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: object value = default(Stamp)
Into: Stamp value = default(Stamp)
*/
struct Stamp { public int Value; }
class Holder { public void Touch(object value = default(Stamp)) { } }
class Program { static void Main() { } }
