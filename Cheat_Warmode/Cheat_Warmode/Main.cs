using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;

namespace Cheat_Warmode {
    public class Main : MonoBehaviour {
        public static Dictionary<string, GalliumMod.Base> ModList = new Dictionary<string, GalliumMod.Base>();

        void Start() {
            Assembly assembly = Assembly.GetAssembly(GetType());
            Type baseType = assembly.GetType((typeof(GalliumMod.Base)).FullName);

            foreach (Type type in assembly.GetTypes()) {

                if (type.IsSubclassOf(baseType)) {

                    ModList.Add(type.Name, (GalliumMod.Base)assembly.CreateInstance(type.FullName));
                }
            }
        }

        void Update() {
            foreach (GalliumMod.Base Mod in ModList.Values) {
                if (UnityEngine.Input.GetKeyDown(Mod.Keybind)) {
                    Mod.Toggle();
                }

                if (Mod.IsEnabled) {
                    Mod.Update();
                }
            }

        }
    }
}
