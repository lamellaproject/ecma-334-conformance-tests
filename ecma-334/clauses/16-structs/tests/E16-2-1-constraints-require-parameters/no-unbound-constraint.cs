/*
Rules: E16-2-1-constraints-require-parameters
Authority: ECMA-334 7th ed 16.2.1
Version: 7.3
Expected: reject
Mutate: struct Named where T : class
Into: struct Named<T> where T : class
*/
struct Named where T : class { }
class Program { static void Main() { } }
