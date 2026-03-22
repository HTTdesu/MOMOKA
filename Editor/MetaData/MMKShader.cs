using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOMOKA.MetaData
{
    [CreateAssetMenu(fileName = "New Shader", menuName = MMKCommon.CreateMMKShaderMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 1)]
    public class MMKShader : ScriptableObject
    {
        public string ShaderName;
        public string FallBack;
        public string CustomEditor;

        public MMKShaderPass[] passes;
    }
}