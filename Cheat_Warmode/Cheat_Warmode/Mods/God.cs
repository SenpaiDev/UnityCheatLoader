using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat_Warmode.Mods {
    class God : GalliumMod.Base {
        private float OldWalk = 6.5f;
        
        public God() : base() {
            Name = "StatFucker";
            Description = "Allows you to move faster then normal.";
            Keybind = KeyCode.P;
        }

        public override void LevelLoaded() {
            //Settings.Cur = LocalPlayer.FpCharacter.walkSpeed;
        }

        public override void OnEnabled() {


            //OldWalk = LocalPlayer.FpCharacter.walkSpeed;

        }

        public override void OnDisabled() {
            //  LocalPlayer.FpCharacter.walkSpeed = OldWalk;
        }

        public override void Update() {
            PlayerControll.Player[Client.ID].nope = Guid.NewGuid().ToString();
          
            //LocalPlayer.FpCharacter.walkSpeed = 100f;
        }
    }
}
