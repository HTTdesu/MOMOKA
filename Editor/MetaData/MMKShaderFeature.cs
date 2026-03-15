using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOMOKA.MetaData
{
    [CreateAssetMenuAttribute(fileName = "New Shader Feature", menuName = MMKCommon.CreateMMKShaderFeatureMenuItem, order = 3)]
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
