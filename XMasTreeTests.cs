using NUnit.Framework;
using System.Collections.Generic;
namespace xmastree;

public class XMasTreeTests
{
    [Test]
    public void Height_0_creates_an_empty_list()
    {
        CollectionAssert.AreEqual(new List<string>(), XMasTree(0));
    }
}