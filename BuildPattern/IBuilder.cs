using DesignPaterns.ComponentPatern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.BuildPattern
{
    interface IBuilder
    {
        GameObject GetResult();
        void BuildGameObject();
    }
}
