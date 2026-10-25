/*
Rules: P09-init-modreq
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: init { retained = value; }
Into: set { retained = value; }
*/
using System;
using System.Reflection;

// init.md: the setter return carries IsExternalInit even with a source body.
class Cargo
{
    int retained;
    public int Payload { get { return retained; } init { retained = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Cargo cargo = new Cargo { Payload = 41 };
        Check(cargo.Payload == 41, "body-stores-initializer-value");
        MethodInfo setter = typeof(Cargo).GetMethod("set_Payload");
        Type[] markers = setter.ReturnParameter.GetRequiredCustomModifiers();
        Check(markers.Length == 1 && markers[0] == typeof(System.Runtime.CompilerServices.IsExternalInit), "body-setter-return-init-marker");
        Check(setter.GetParameters()[0].GetRequiredCustomModifiers().Length == 0, "body-setter-value-has-no-marker");
        Check(typeof(Cargo).GetMethod("get_Payload").ReturnParameter.GetRequiredCustomModifiers().Length == 0, "getter-return-has-no-init-marker");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
