/*
Rules: E18-2-2-duplicate-modifier
Authority: ECMA-334 7th ed 18.2.2
Version: 7.3
Expected: reject
Mutate: public public interface IMarker
Into: public interface IMarker
Csc: CS1004
*/
public public interface IMarker { }
class Program { static void Main() { } }
