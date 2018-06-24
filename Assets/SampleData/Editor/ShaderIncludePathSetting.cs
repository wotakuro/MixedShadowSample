using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

namespace App
{
    public class ShaderIncludePathSetting
    {

        [ShaderIncludePath]
        public static string[] GetPaths()
        {
            return new[]
            {
            "Assets/UnitySoftware/ScriptableRenderPipeline/Core/",
            "Assets/UnitySoftware/ScriptableRenderPipeline/LightWeightPipeline/",
        };
        }
    }
}
