using DesignPaterns.ComponentPatern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.FactoryPattern
{
    public abstract class Factory
    {
        public abstract GameObject Create(string type);
    }
}
