using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class Coupling
{
    // A Test behaves as an ordinary method
    [Test]
    public void Test()
    {
        var a = Substitute.For<I_A>();
        var b = Substitute.For<I_B>();

        var resultA = 1;
        var resultB = 2;
        a.GetResult().Returns(resultA);
        b.GetResult().Returns(resultB);
        var c = new C(a , b);
        var expectedResult = 3;
        var result = c.GetResult();

        Assert.AreEqual(expectedResult , result);
    }

}

public interface I_A
{
    int GetResult();
}
public class A : I_A
{
    public int GetResult() {
        return 1;
    }
}

public interface I_B
{
    int GetResult();
}

public class B : I_B
{
    public int GetResult() {
        return 2;
    }
}

public class C
{
    private readonly I_A a;
    private readonly I_B b;
    
    public C(I_A a,I_B b) {
        this.a = a;
        this.b = b;
    }

    public int GetResult() {
        var resulta = a.GetResult();
        var resultb = b.GetResult();
        return resulta + resultb;
    }
}
