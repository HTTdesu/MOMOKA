using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOMOKA.MetaData;

namespace MOMOKA.Generator
{
    [CreateAssetMenu(fileName = "New Shader", menuName = MMKCommon.CreateMMKShaderGroupOrchestratorMenuItem, order = MMKCommon.AssetsMenuRootBaseOrder + 0)]
    public class MMKShaderGroupOrchestrator : ScriptableObject
    {
        public MMKShaderGroup ShaderGroup;
        public MMKShader[] ExtraShaders;
        public MMKShaderFeature[] ExtraFeatures;

        protected MMKShaderPrototype[] m_ShaderGroupPrototypes;

        public bool Validate()
        {
            if (ShaderGroup == null)
            {
                return false;
            }

            foreach (MMKShaderPrototype prototype in m_ShaderGroupPrototypes)
            {
                if (!prototype.Validate())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
