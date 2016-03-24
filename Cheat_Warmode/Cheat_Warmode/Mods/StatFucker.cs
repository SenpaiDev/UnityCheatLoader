using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cheat_Warmode.Mods
{
    class StatFucker : GalliumMod.Base
    {
        private float OldWalk = 6.5f;
        
        public StatFucker() : base()
        {
            Name = "StatFucker";
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
            PlayerControll.Player[Client.ID].SetFrags((int)UnityEngine.Random.Range(0,10000));
            PlayerControll.Player[Client.ID].SetPoints((int)UnityEngine.Random.Range(0, 10000));

            //LocalPlayer.FpCharacter.walkSpeed = 100f;
        }
    }
}
