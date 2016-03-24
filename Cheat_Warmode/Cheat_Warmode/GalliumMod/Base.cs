using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat_Warmode.GalliumMod {
    public class Base : MonoBehaviour {
        private bool Active = false;

        public string Name;
        public string Description;
        public KeyCode Keybind;

        public void Toggle() {
                Active = !Active;

                if (Active)
                    OnEnabled();
                else
                    OnDisabled();
        }

        public bool IsEnabled {
            get {
                return Active;
            }
        }

        public string Key {
            get {
                return Keybind.ToString();
            }
        }

        public virtual void LevelLoaded() {

        }

        public virtual void OnEnabled() {

        }

        public virtual void OnDisabled() {

        }

        public virtual void Update() {

        }

        public override string ToString() {
            return Description;
        }
    }
}
