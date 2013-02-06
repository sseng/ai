using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringGame
{
    interface gameNode
    {
        int g();
        int h();
        List<gameNode> children();
    }
}
