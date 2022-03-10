using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace xmastree;
using static XMas;

public class XMasTreeTests
{
    
    [Test]
    public void Negative_height_is_not_allowed([Values(-1,-2, int.MinValue)]int negativeHeight)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => XMasTree(negativeHeight));
    }

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
    public void Treetop_is_always_one_unit_wide(int height)
    {
        var tree = XMasTree(height);
        var top = tree.First();
        Assert.AreEqual(1, top.Count(x => x == '#'));
    }

    [TestCase(1,0)]
    [TestCase(2,1)]
    public void Treetop_is_always_in_the_middle(int height, int middle)
    {
        var tree = XMasTree(height);
        var top = tree.First();
        Assert.AreEqual(middle, top.IndexOf('#'));
    }

    [Test]
    public void Lower_trunk_is_one_unit_wide([Values(1,2,3)]int height)
    {
        var tree = XMasTree(height);
        var lowerTrunk = tree.Last();
        Assert.AreEqual(1, lowerTrunk.Count(x => x == '#'));
    }

    [TestCase(1,0)]
    [TestCase(2,1)]
    [TestCase(3,2)]
    public void Lower_trunk_is_in_the_middle(int height, int middle)
    {
        var tree = XMasTree(height);
        var lowerTrunk = tree.Last();
        Assert.AreEqual(middle, lowerTrunk.IndexOf('#'));
    }

    [Test]
    public void Height_2_or_more_grows_upper_trunk_one_unit_wide([Values(2,3)]int height)
    {
        var tree = XMasTree(height);
        var upperTrunk = tree[tree.Count-2];
        Assert.AreEqual(1, upperTrunk.Count(x => x == '#'));
    }

    [TestCase(2,1)]
    [TestCase(3,2)]
    public void Height_2_or_more_grows_upper_trunk_in_the_middle(int height, int middle)
    {
        var tree = XMasTree(height);
        var upperTrunk = tree[tree.Count-2];
        Assert.AreEqual(middle, upperTrunk.IndexOf('#'));
    }

    [Test]
    public void Height_2_creates_tree_whose_widest_part_sits_on_top_of_the_stem()
    {
        var tree = XMasTree(2);
        var widestPart = tree[tree.Count-3];
        CollectionAssert.AreEqual("###", widestPart);
    }

    [Test]
    public void Treetop_is_padded_to_match_the_widest_part_of_the_tree()
    {
        var tree = XMasTree(2);
        var top = tree.First();
        Assert.AreEqual(2, top.Count(x => x == '_'));
    }

    [TestCase(1,0)]
    [TestCase(2,2)]
    [TestCase(3,4)]
    public void Lower_trunk_is_padded_to_match_the_widest_part_of_the_tree(int height, int padding)
    {
        var tree = XMasTree(height);
        var lowerTrunk = tree.Last();
        Assert.AreEqual(padding, lowerTrunk.Count(x => x == '_'));
    }

    [TestCase(2,2)]
    [TestCase(3,4)]
    public void Upper_trunk_is_padded_to_match_the_widest_part_of_the_tree(int height, int padding)
    {
        var tree = XMasTree(height);
        var upperTrunk = tree[tree.Count-2];
        Assert.AreEqual(padding, upperTrunk.Count(x => x == '_'));
    }
}