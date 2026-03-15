using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEditor;

namespace MOMOKA.MetaData
{
    [CreateAssetMenuAttribute(fileName = "New Shader Product", menuName = MMKCommon.CreateMMKShaderGroupMenuItem, order = 0)]
    public class MOMOKAShaderGroup : ScriptableObject
    {
        public string ShaderProduceName;
        public MMKShader[] Shaders;
    }
}
