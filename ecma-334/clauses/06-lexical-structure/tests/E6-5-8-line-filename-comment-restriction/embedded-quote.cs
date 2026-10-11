/*
Rules: E6-5-8-line-filename-comment-restriction
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: reject
Mutate: "name"bad"
Into: "name"
*/
#line 1 "name"bad"
class Program { static void Main() { } }
