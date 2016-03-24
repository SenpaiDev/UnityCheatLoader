using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Cheat_Warmode {
    public class Style : MonoBehaviour {
        private static Texture2D DarkBG = new Texture2D(1, 1, TextureFormat.Alpha8, false);
        public static GUIStyle Center = new GUIStyle();
        public static GUIStyle RichText = new GUIStyle();
        public static GUIStyle RichTextCenter = new GUIStyle();
        public static GUIStyle Warning = new GUIStyle();

        void Start() {
            Center.normal.textColor = Color.white;
            Center.alignment = TextAnchor.MiddleCenter;

            RichText.richText = true;

            RichTextCenter.richText = true;
            RichTextCenter.alignment = TextAnchor.MiddleCenter;

            Warning.alignment = TextAnchor.MiddleCenter;
            Warning.normal.textColor = Color.red;
            Warning.normal.background = DarkBG;
        }
    }

    public static class Utils {
        public static string[] SpamArray = {
            "cock"
        };

        public static string IsEnabled(this string str, bool value) {
            return value ? $"[ {str} ]" : str;
        }

        public static string ToToggle(this bool b) {
            return b ? "Enabled" : "Disabled";
        }

        public static Vector3 ToVector3(this string str) {
            string[] s = str.Substring(1, str.Length - 2).Split(',');
            Vector3 v = Vector3.zero;

            if (float.TryParse(s[0], out v.x) && float.TryParse(s[1], out v.y) && float.TryParse(s[2], out v.z))
                return v;

            return Vector3.zero;
        }

        public static bool InGame() {
            if (Application.loadedLevelName == "TitleScene")
                return false;
            return true;
        }

        public static void RemoteInvoke(object from, string method, params object[] args) {
            Type instance = from.GetType();
            MethodInfo call = instance.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);

            call.Invoke(from, args);
        }

        public static void AdvInvoke(this MonoBehaviour behaviour, string method, params object[] options) {
            behaviour.StartCoroutine(_invoke(behaviour, method, options));
        }

        private static System.Collections.IEnumerator _invoke(this MonoBehaviour behaviour, string method, object[] options) {
            Type instance = behaviour.GetType();
            MethodInfo mthd = instance.GetMethod(method);
            mthd.Invoke(behaviour, options);

            yield return null;
        }
    }

    public class ReflectionUtil {
        public static void SetField<T>(object instance, string name, object value) {
            instance.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance).SetValue(instance, (T)value);
        }

        public static T GetField<T>(object instance, string name) {
            return (T)instance.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);
        }

        public static void RemoteInvoke(object instance, string name, params object[] args) {
            instance.GetType().GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(instance, args);
        }
    }
}