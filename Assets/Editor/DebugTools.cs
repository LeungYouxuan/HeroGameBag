using System;
using QFramework;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class DebugTools:EditorWindow,IController
    {
        [MenuItem("Tools/调试工具")]
        public static void ShowWindow()
        {
            GetWindow<DebugTools>("调试工具");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("刷新背包"))
            {
                
            }
        }

        public IArchitecture GetArchitecture()
        {
            return GameArch.Interface;
        }
    }
}