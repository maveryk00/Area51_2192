using System.Collections;
using System.Collections.Generic;

namespace FPTD {
    public class Resources {
        public enum Type {
            gold, metal
        }


        public Dictionary<Type, int> resourcesDictionary;

        public int gold {
            get {
                return resourcesDictionary[Type.gold];
            }
        }

        public int metal {
            get {
                return resourcesDictionary[Type.metal];
            }
        }


        public Resources() {
            RegisterResources();
        }

        public void RegisterResources() {
            resourcesDictionary = new Dictionary<Type, int>();
            AddResource(Type.gold, 1000);
            AddResource(Type.metal, 0);
        }

        public void AddResource(Type type, int quantity) {
            if (resourcesDictionary.ContainsKey(type))
                resourcesDictionary[type] += quantity;
            else
                resourcesDictionary.Add(type, quantity);
        }

        public bool ConsumeResource(Type type, int quantity) {
            bool canConsume = false;

            if (resourcesDictionary.ContainsKey(type)) {
                if (resourcesDictionary[type] >= quantity) {
                    resourcesDictionary[type] -= quantity;
                    canConsume = true;
                }
            }
            //else
            //  msg error

            return canConsume;
        }
    }
}