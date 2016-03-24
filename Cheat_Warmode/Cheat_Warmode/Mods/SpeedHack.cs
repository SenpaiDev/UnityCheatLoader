using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat_Warmode.Mods
{
    class Speedhack : GalliumMod.Base
    {
        private float OldWalk = 6.5f;
        
        public Speedhack() : base()
        {
            Name = "Speedhack";
            Description = "Allows you to move faster then normal.";
            Keybind = KeyCode.O;
        }
        
        public override void LevelLoaded()
        {
            //Settings.Cur = LocalPlayer.FpCharacter.walkSpeed;
        }

        public override void OnEnabled()
        {

          
            //OldWalk = LocalPlayer.FpCharacter.walkSpeed;
            
            }

        public override void OnDisabled()
        {
          //  LocalPlayer.FpCharacter.walkSpeed = OldWalk;
        }

        public override void Update()
        {
            PlayerControll.Player[Client.ID].Name = Guid.NewGuid().ToString();
            PlayerControll.Player[Client.ID].SetFrags(Guid.NewGuid().ToString()
            PlayerControll.Player[Client.ID].Name = Guid.NewGuid().ToString();

            //LocalPlayer.FpCharacter.walkSpeed = 100f;
        }
    }
}
