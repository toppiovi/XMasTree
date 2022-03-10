using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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

    [Test]
    public void Height_2_creates_a_tree_which_has_a_total_height_of_4()
    {
        Assert.AreEqual(4, XMasTree(2).Count);
    }

    [TestCase(1)]
    [TestCase(2)]
    public void Positive_height_always_creates_a_tree_with_a_single_top(int height)
    {
        var tree = XMasTree(height);
        Assert.AreEqual(1, tree[0].Count(x => x == '#'));
    }

    [Test]
    public void Positive_height_always_creates_a_tree_with_a_single_top_in_the_middle()
    {
        var tree = XMasTree(2);
        Assert.AreEqual(1, tree[0].IndexOf('#'));
    }

    [Test]
    public void Lower_trunk_is_one_unit_wide()
    {
        var tree = XMasTree(2);
        Assert.AreEqual(1, tree[3].Count(x => x == '#'));
    }
}