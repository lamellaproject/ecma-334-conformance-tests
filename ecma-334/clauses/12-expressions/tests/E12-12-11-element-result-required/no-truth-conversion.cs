/*
Rules: E12-12-11-element-result-required
Authority: ECMA-334 7th ed 12.12.11
Version: 7.3
Expected: reject
Mutate: class Result { }
Into: class Result { public static implicit operator bool(Result r) { return true; } }
*/
class Result { }
class Number
{
    public static Result operator ==(Number x, Number y) { return new Result(); }
    public static Result operator !=(Number x, Number y) { return new Result(); }
    public override bool Equals(object x) { return false; }
    public override int GetHashCode() { return 0; }
}
class Program { static void Main() { bool b = (new Number(), 1) == (new Number(), 1); } }
