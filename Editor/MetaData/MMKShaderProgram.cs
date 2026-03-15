using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOMOKA.MetaData
{
    public abstract class MMKShaderProgram : ScriptableObject
    {
        public MMKShaderBinding[] ShaderProgramInput;
        public MMKShaderBinding[] ShaderProgramOutput;
        public MMKShaderCodeSnap[] ShaderCode;
    }

    [CreateAssetMenuAttribute(fileName = "New Vertex Program", menuName = MMKCommon.CreateMMKVertexProgramMenuItem, order = 100)]
    public class MMKVertexProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenuAttribute(fileName = "New Hull Program", menuName = MMKCommon.CreateMMKHullProgramMenuItem, order = 101)]
    public class MMKHullProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenuAttribute(fileName = "New Domain Program", menuName = MMKCommon.CreateMMKDomainProgramMenuItem, order = 102)]
    public class MMKDomainProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenuAttribute(fileName = "New Geometry Program", menuName = MMKCommon.CreateMMKGeometryProgramMenuItem, order = 103)]
    public class MMKGeometryProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenuAttribute(fileName = "New Material Program", menuName = MMKCommon.CreateMMKMaterialProgramMenuItem, order = 104)]
    public class MMKMaterialProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenuAttribute(fileName = "New Lighting Program", menuName = MMKCommon.CreateMMKLightingProgramMenuItem, order = 105)]
    public class MMKLightingProgram : MMKShaderProgram
    {

    }
}
