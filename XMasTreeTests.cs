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
        var top = tree.First();
        Assert.AreEqual(1, top.Count(x => x == '#'));
    }

    [Test]
    public void Positive_height_always_creates_a_tree_with_a_single_top_in_the_middle()
    {
        var tree = XMasTree(2);
        var top = tree.First();
        Assert.AreEqual(1, top.IndexOf('#'));
    }

    [Test]
    public void Lower_trunk_is_one_unit_wide()
    {
        var tree = XMasTree(2);
        var lowerTrunk = tree.Last();
        Assert.AreEqual(1, lowerTrunk.Count(x => x == '#'));
    }

    [Test]
    public void Upper_trunk_is_one_unit_wide()
    {
        var tree = XMasTree(2);
        var upperTrunk = tree[tree.Count-2];
        Assert.AreEqual(1, upperTrunk.Count(x => x == '#'));
    }

    [Test]
    public void Height_2_creates_tree_which_grows_wider_towards_the_stem()
    {
        var tree = XMasTree(2);
        CollectionAssert.AreEqual("###", tree[1]);
    }

    [Test]
    public void Treetop_is_padded_to_match_the_widest_part_of_the_tree()
    {
        var tree = XMasTree(2);
        var top = tree.First();
        Assert.AreEqual(2, top.Count(x => x == '_'));
    }

    [Test]
    public void Lower_trunk_is_padded_to_match_the_widest_part_of_the_tree()
    {
        var tree = XMasTree(2);
        var lowerTrunk = tree.Last();
        Assert.AreEqual(2, lowerTrunk.Count(x => x == '_'));
    }

    [Test]
    public void Upper_trunk_is_padded_to_match_the_widest_part_of_the_tree()
    {
        var tree = XMasTree(2);
        var upperTrunk = tree[tree.Count-2];
        Assert.AreEqual(2, upperTrunk.Count(x => x == '_'));
    }
}