using NUnit.Framework;
using System.Collections.Generic;
namespace xmastree;
using static XMas;

public class XMasTreeTests
{
    [Test]
    public void Height_0_creates_an_empty_list()
    {
        CollectionAssert.AreEqual(new List<string>(), XMasTree(0));
    }

    [Test]
    public void Height_1_creates_a_tree_with_a_trunk_of_height_1_and_a_crown_of_height_1()
    {
        CollectionAssert.AreEqual(new List<string>{"#", "#"}, XMasTree(1));
    }
}