/*
Rules: E12-8-16-7-property-hash; E12-8-16-7-hash-override; E12-8-16-7-equals-override
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: var same = new { Count = 7, Token = new Key(19) };
Into: var same = new { Count = 23, Token = new Key(19) };
*/
using System;
using System.Reflection;
class Key
{
    public int Number;
    public Key(int number) { Number = number; }
    public override bool Equals(object other) { Key value = other as Key; return value != null && value.Number == Number; }
    public override int GetHashCode() { return Number; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var first = new { Count = 7, Token = new Key(19) };
        var same = new { Count = 7, Token = new Key(19) };
        Type type = first.GetType();
        MethodInfo equals = type.GetMethod("Equals", new Type[] { typeof(object) });
        MethodInfo hash = type.GetMethod("GetHashCode", new Type[0]);
        bool equalsOverride = equals != null && equals.DeclaringType == type && equals.IsVirtual &&
                              equals.GetBaseDefinition().DeclaringType == typeof(object);
        bool hashOverride = hash != null && hash.DeclaringType == type && hash.IsVirtual &&
                            hash.GetBaseDefinition().DeclaringType == typeof(object);
        Check(equalsOverride, "anonymous-overrides-object-equals");
        Check(hashOverride, "anonymous-overrides-object-hash");
        // Equal property hashes require equal object hashes; unequal values may collide.
        Check(first.GetHashCode() == same.GetHashCode(), "equal-property-hashes-give-equal-anonymous-hashes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
