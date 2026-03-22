using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOMOKA.MetaData;

namespace MOMOKA.Generator
{
    [CreateAssetMenu(fileName = "New Shader", menuName = MMKCommon.CreateMMKShaderOrchestratorMenuItem, order = MMKCommon.AssetsMenuRootBaseOrder + 1)]
    public class MMKShaderOrchestrator : ScriptableObject
    {
        public MMKShader Shader;
        public MMKShaderFeature[] ExtraFeatures;

        protected MMKShaderPrototype m_ShaderPrototype;
    }
}
