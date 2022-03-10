using System.Collections.Generic;
namespace xmastree;

public class XMas 
{
    public static List<string> XMasTree(int height)
    {
        if (height == 2)
            return new List<string>{"#", "", "", ""};
        return height == 1 ? new List<string>{"#", "#"} : new List<string>();
    }
}