using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOMOKA.MetaData
{
    [CreateAssetMenu(fileName = "New Shader Feature", menuName = MMKCommon.CreateMMKShaderFeatureMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 3)]
    public class MMKShaderFeature : ScriptableObject
    {
        public MMKShaderProgram VertexStage;
        public MMKShaderProgram HullStage;
        public MMKShaderProgram DomainStage;
        public MMKShaderProgram GeometryStage;
        public MMKShaderProgram MaterialStage;
        public MMKShaderProgram LightingStage;
    }
}
