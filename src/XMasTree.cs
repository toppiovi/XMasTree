namespace xmastree;

public class XMas 
{
    public static List<string> XMasTree(int height)
    {
        var xmas = new XMas(height);
        return xmas.GrowTree();
    }

    private int height;

    public XMas(int height)
    {
        if (height < 0)
            throw new ArgumentOutOfRangeException();

        this.height = height;
    }

    public List<string> GrowTree()
    {
        if (height == 0)
            return new List<string>();
        var leaves = GrowLeaves();
        var tree = GrowTrunk(leaves);
        return tree;
    }

    private List<string> GrowLeaves()
    {
        var leaves = new List<string>();
        int treeWidth = 1;
        int paddingWidth = MaxPaddingWdith();
        
        for (int i = 0; i < height; i++)
        {
            leaves.Add(PaddedTreePart(treeWidth, paddingWidth));
            treeWidth += 2;
            paddingWidth--;
        }

        return leaves;
    }

    private int MaxPaddingWdith() => height-1;

    private List<string> GrowTrunk(List<string> tree)
    {
        tree.Add(PaddedTrunk());
        if (height > 1)
            tree.Add(PaddedTrunk());
        return tree;
    }

    private string PaddedTrunk()
    {
        return PaddedTreePart(1, MaxPaddingWdith());
    }

    private static string PaddedTreePart(int treeWidth, int paddingWidth)
    {
        var treePart = InitStringWith('#', treeWidth);
        return AddPadding(treePart, paddingWidth);
    }

    private static string AddPadding(string treePart, int paddingWidth)
    {
        var padding = InitStringWith('_', paddingWidth);
        return padding + treePart + padding;
    }

    private static string InitStringWith(char value, int n) {
        return new String(Enumerable.Repeat(value, n).ToArray());
    }
}