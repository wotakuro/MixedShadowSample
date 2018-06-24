using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace App
{
    public class MyCustomeRenderPipelineCreate
    {
        public static void Create()
        {

            var instance = ScriptableObject.CreateInstance<App.MyCustomRenderPipelineAsset>();
            AssetDatabase.CreateAsset(instance, "Assets/MyScriptableRenderPipeline.asset");

        }
    }

}
