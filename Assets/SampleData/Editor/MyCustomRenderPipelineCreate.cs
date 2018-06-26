using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace App
{

    public class MyCustomeRenderPipelineCreate
    {
        [MenuItem("Tool/test")]
        public static void Create()
        {

            var instance = ScriptableObject.CreateInstance<MyCustomRenderPipelineAsset>();
            AssetDatabase.CreateAsset(instance, "Assets/MyScriptableRenderPipeline.asset");

        }
    }

}
