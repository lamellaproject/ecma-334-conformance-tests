/*
Rules: E12-6-3-10-lower-constructed-shape
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Read(new Leaf())
Into: Read(new Holder<int>())
*/
using System;
class Holder<T> { }
class Leaf : Holder<long> { }
interface View<T> { }
class ViewHolder : View<string> { }
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Read<T>(Holder<T> x) { return new Result<T>(); }
    static Result<T> Read<T>(View<T> x) { return new Result<T>(); }
    static Result<long> ThroughBase<S>(S source) where S : Holder<long> { return Read(source); }
    static Result<string> ThroughInterface<S>(S source) where S : View<string> { return Read(source); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<long> direct = Read(new Leaf());
        Check(direct != null, "inference-traverses-constructed-base-class");
        Check(ThroughBase(new Leaf()) != null, "type-parameter-effective-base-provides-inference-shape");
        Check(ThroughInterface(new ViewHolder()) != null, "type-parameter-effective-interface-provides-inference-shape");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
