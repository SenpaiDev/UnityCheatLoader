using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Cheat_Warmode {
    public class GalliumGUI : MonoBehaviour {
        public GUIStyle CatStyle = null;
        public GUIStyle SelStyle = null;
        public GUIStyle SelectedStyle = null;

        public float Menuheight = Screen.height / 2 - 150;
        public float MenuWidth = Screen.width / 2 - 250;
        public bool MenuTog = false;
        /*
        public enum MenuTypes
        {
            Player,
            Online,
            Misc,
            Options
        }
        */
        bool Playert;
        bool Onlinet;
        bool Misct;
        bool Worldt;
        bool Optionst;

        void Start() {
            //noting here
        }

        void OnGUI() {
            if (MenuTog) {
                InitStyles();
                GUI.Box(new Rect(MenuWidth + 100, Menuheight, 400, 300), "", SelStyle);
                GUILayout.BeginArea(new Rect(MenuWidth, Menuheight, 100, 300));

                if (GUILayout.Button("Player", Playert ? SelectedStyle : CatStyle, GUILayout.Height(60))) {
                    Onlinet = false; Misct = false; Worldt = false; Optionst = false;
                    Playert = true;
                }

                GUILayout.Space(-4);
                if (GUILayout.Button("Online", Onlinet ? SelectedStyle : CatStyle, GUILayout.Height(60))) {
                    Misct = false; Worldt = false; Playert = false; Optionst = false;
                    Onlinet = true;
                }

                GUILayout.Space(-4);
                if (GUILayout.Button("Misc", Misct ? SelectedStyle : CatStyle, GUILayout.Height(60))) {
                    Misct = true; Worldt = false; Playert = false; Optionst = false;
                    Onlinet = false;
                }

                GUILayout.Space(-4);
                if (GUILayout.Button("World", Worldt ? SelectedStyle : CatStyle, GUILayout.Height(60))) {
                    Misct = false; Worldt = true; Playert = false; Optionst = false;
                    Onlinet = false;
                }

                GUILayout.Space(-4);
                if (GUILayout.Button("Options", Optionst ? SelectedStyle : CatStyle, GUILayout.Height(60))) {
                    Misct = false; Worldt = false; Playert = false; Onlinet = false;
                    Optionst = true;
                }
                GUILayout.EndArea();


                GUILayout.BeginArea(new Rect(MenuWidth + 100, Menuheight, 400, 300));
                GUILayout.BeginHorizontal();
                GUILayout.BeginHorizontal();
                if (Playert) {
                    if (GUILayout.Button("StatFucker")) {
                        Main.ModList["StatFucker"].Toggle();
                    }
                    if (GUILayout.Button("Noclip")) {
                        Main.ModList["Noclip"].Toggle();
                    }
                    if (GUILayout.Button("Test Button")) {

                    }
                }

                if (Onlinet) {

                }

                if (Misct) {

                }

                if (Optionst) {

                }
                GUILayout.EndHorizontal();
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
            }
        }

        void Update() {
            if (UnityEngine.Input.GetKeyDown(KeyCode.J)) {
                MenuTog = !MenuTog;
               // if (MenuTog)
             //       LocalPlayer.FpCharacter.LockView(true);
               // else
               //     LocalPlayer.FpCharacter.UnLockView();
            }
        }

        private void InitStyles() {

            if (SelectedStyle == null) {
                SelectedStyle = new GUIStyle(GUI.skin.button);
                SelectedStyle.normal.background = MakeTex(2, 2, new Color(0.52f, 0.52f, 0.52f, 0.8f));
                SelectedStyle.hover.background = MakeTex(2, 2, new Color(0.52f, 0.52f, 0.52f, 0.8f));
                SelectedStyle.active.background = MakeTex(2, 2, new Color(0.52f, 0.52f, 0.52f, 0.8f));
            }
            if (CatStyle == null) {
                CatStyle = new GUIStyle(GUI.skin.button);
                CatStyle.normal.background = MakeTex(2, 2, new Color(0.32f, 0.32f, 0.32f, 0.8f));
                CatStyle.hover.background = MakeTex(2, 2, new Color(0.32f, 0.32f, 0.32f, 0.8f));
                CatStyle.active.background = MakeTex(2, 2, new Color(0.32f, 0.32f, 0.32f, 0.8f));
            }

            if (SelStyle == null) {
                SelStyle = new GUIStyle(GUI.skin.box);
                SelStyle.normal.background = MakeTex(2, 2, new Color(0.52f, 0.52f, 0.52f, 0.8f));
            }
        }
        private Texture2D MakeTex(int width, int height, Color col) {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i) {
                pix[i] = col;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
    }
}
