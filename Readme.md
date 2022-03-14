# XMasTree
![Ubuntu Build](https://github.com/toppiovi/XMasTree/actions/workflows/dotnet.yml/badge.svg)

This Kata is taken from [CodeWars](https://www.codewars.com/kata/577c349edf78c178a1000108/go) and is implemented in C#.
#### TL;DR
In short, this kata is about growing an Xmas tree, based on an input height. 
Padding is applied to keep the overall image rectangular. Additionally, the trunk grows maximum two units high.

```

____#____              1
___###___              2
__#####__              3
_#######_              4
#########       -----> 5 - Height of Tree
____#____        1      
____#____        2 - Trunk/Stem of Tree
```

## TDD
I implemented this Kata in TDD style, which can be followed in detail in the git history graph (red - green - refactor).

In order to define the contract for the method under test, I started off with very simple examples like specifying what happens with an input height of 0. 
```
[Test]
public void Height_0_creates_an_empty_list()
{
    CollectionAssert.AreEqual(new List<string>(), XMasTree(0));
}
```

After a while, I started focusing on the symmetry of the tree.
The following tests describe, how the treetop is always one unit wide and resides in the middle of the tree. 
```
public class Treetop 
{
    [Test]
    public void Is_always_one_unit_wide([Values(1,2,3,5)]int height)
    {
        var tree = XMasTree(height);
        var top = tree.First();
        Assert.AreEqual(1, top.Count(x => x is '#'));
    }

    [TestCase(1,0)]
    [TestCase(2,1)]
    [TestCase(3,2)]
    public void Is_always_in_the_middle(int height, int middle)
    {
        var tree = XMasTree(height);
        var top = tree.First();
        Assert.AreEqual(middle, top.IndexOf('#'));
    }
``` 

Focussing on the tree symmetry and progressing in very small incements allowed me to drive the implementation towards establishing a tree growing algorithm.
I did regular refactorings, but once I had found a good test harness, I took some longer turns for refactoring.
Once the algorithm was established, I could restructure the tests a little, giving them the same attention as the "production code".
The final algorithm grows each row of the tree one by one, creating the leaves first and finishing off with the trunk.

```
public List<string> GrowTree()
{
    if (height == 0)
        return new List<string>();

    var leaves = GrowLeaves();
    var tree = GrowTrunk(leaves);
    return tree;
}
```

Overall I made a very smooth experience solving this kata, but it was quite some work and more than 100 commits (baby steps!). 

## Build and Test
For building and testing this project, simply run the following command.
```
cd tests && dotnet test
```

## Mutation Testing Using Stryker
Tests and production code should be treated equally and should be given the same amount of attention.
For verifying the quality of tests and code, I used [Stryker](https://stryker-mutator.io/docs/stryker-net/introduction/). This nice tool mutates the production code and runs all tests against its mutations. 
```
   _____ _              _               _   _ ______ _______  
  / ____| |            | |             | \ | |  ____|__   __| 
 | (___ | |_ _ __ _   _| | _____ _ __  |  \| | |__     | |    
  \___ \| __| '__| | | | |/ / _ \ '__| | . ` |  __|    | |    
  ____) | |_| |  | |_| |   <  __/ |    | |\  | |____   | |    
 |_____/ \__|_|   \__, |_|\_\___|_| (_)|_| \_|______|  |_|    
                   __/ |                                      
                  |___/
```
If a mutation survives, it can have several meanings. 
Most of the times, there was no test to cover the behavioral change.
You may also find out, that a code block was simply not required and can simply be removed, resulting in reduction of code complexity. 

As an example, Stryker helped me to detect, that this whole function was completely obsolete.
```
   private static bool NoPaddingRequired(int totalPaddingWidth)
-  {
-     return totalPaddingWidth == 0;
-  }
+  {}
```

### Setup and Run Stryker
Stryker requires the production code project to be separate from the test project.

Stryker is already part of the dotnet tool manifest. 
Restore Stryker using
```
dotnet tool restore
```

Run Stryker using the following command form the `./tests` directory. It will generate an HTML report, which is especually helpful for showing the survived mutations.
```
dotnet stryker
```

Stryker was installed using
```
dotnet new tool-manifest
dotnet tool install dotnet-stryker
```

## Kata Description

Complete the function that returns a christmas tree of the given height. The height is passed through to the function and the function should return a list containing each line of the tree.

XMasTree(5) should return : `['____#____', '___###___', '__#####__', '_#######_', '#########', '____#____', '____#____']`

XMasTree(3) should return : `['__#__', '_###_', '#####', '__#__', '__#__']`

Pad with underscores (_) so each line is the same length. Also remember the trunk/stem of the tree.

### Examples
The final idea is for the tree to look like this if you decide to print each element of the list:

n = 5 will result in:
```

____#____              1
___###___              2
__#####__              3
_#######_              4
#########       -----> 5 - Height of Tree
____#____        1      
____#____        2 - Trunk/Stem of Tree
```
n = 3 will result in:
```

__#__                  1
_###_                  2
#####          ----->  3 - Height of Tree
__#__           1
__#__           2 - Trunk/Stem of Tree

```
