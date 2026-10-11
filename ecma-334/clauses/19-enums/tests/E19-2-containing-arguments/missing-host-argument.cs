/*
Rules: E19-2-containing-arguments
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: reject
Mutate: Host.Code item
Into: Host<int>.Code item
*/
class Host<T> { public enum Code { Mark } }
class Program { static void Main() { Host.Code item = 0; } }
