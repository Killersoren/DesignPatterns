using DesignPaterns.ComponentPatern;
using DesignPaterns.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPaterns.ObjectPool
{
    class PlatformPool : ObjectPool
    {
        private static PlatformPool instance;
        public static PlatformPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlatformPool();
                }
                return instance;
            }
        }

        protected override void Cleanup(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        protected override GameObject Create()
        {
            return PlatformFactory.Instance.Create("Blue");

        }
    }
}
