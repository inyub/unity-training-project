using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;

namespace ArtistTools.Tools
{
    public class CalculatorPro : EditorWindow
    {
        public float a = 2;
        public float b = 2;
        public float c;

        public string inputText = "Type here";
        public int charLength;
        public int charLength2;
        public int charLength3;


        void OnGUI()
        {
            GUILayout.Label("Aspect Ratio Calculator", EditorStyles.boldLabel);
            a = EditorGUILayout.FloatField("Width:", a);
            b = EditorGUILayout.FloatField("Height:", b);
            c = EditorGUILayout.FloatField("Aspect Ratio:", c);

            GUILayout.Label("Text Length Calculator", EditorStyles.boldLabel);
            inputText = EditorGUILayout.TextField("How long is:", inputText);
            charLength = EditorGUILayout.IntField("Text Length: ", charLength);
            charLength2 = EditorGUILayout.IntField("Only Words: ", charLength2);
            charLength3 = EditorGUILayout.IntField("Only Characters: ", charLength3);
        }

        void Update()
        {
            c = a / b;
            charLength = inputText.Length;
            charLength2 = inputText.Split().Length;
            charLength3 = inputText.Replace(" ", string.Empty).Length;
        }

        [MenuItem("ArtistTools/Tools/Common UI Calcs")]
        public static void ShowWindow()
        {
           EditorWindow _windowInstance = EditorWindow.GetWindow(typeof(CalculatorPro));
           _windowInstance.titleContent = new GUIContent("Common UI Calcs");
        }
    }
}



