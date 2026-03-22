using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEditor;

namespace MOMOKA.MetaData
{
    [CreateAssetMenu(fileName = "New Shader Product", menuName = MMKCommon.CreateMMKShaderGroupMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 0)]
    public class MMKShaderGroup : ScriptableObject
    {
        public string ShaderProduceName;
        public MMKShader[] Shaders;
    }
}
