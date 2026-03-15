using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MOMOKA.MetaData
{
    [CreateAssetMenuAttribute(fileName = "New Shader", menuName = MMKCommon.CreateMMKShaderMenuItem, order = 1)]
    public class MMKShader : ScriptableObject
    {
        public string ShaderName;
        public string FallBack;
        public string CustomEditor;

        public MMKShaderPass[] passes;
    }
}