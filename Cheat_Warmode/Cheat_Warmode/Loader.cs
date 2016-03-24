using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat_Warmode
{
   class Loader
    {
        public static GameObject GalliumObject;

        public static void Load()
        {
                GalliumObject = new GameObject();
                GalliumObject.AddComponent<Main>();
                //GalliumObject.AddComponent<Console>();
                GalliumObject.AddComponent<GalliumGUI>();
                UnityEngine.Object.DontDestroyOnLoad(GalliumObject);
            }
        }
    }

