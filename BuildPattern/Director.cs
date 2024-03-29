﻿using DesignPaterns.ComponentPatern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.BuildPattern
{
    class Director
    {
        private IBuilder builder;
        public Director(IBuilder builder)
        {
            this.builder = builder;
        }
        public GameObject Construct()
        {
            builder.BuildGameObject();
            return builder.GetResult();
        }
    }
}
