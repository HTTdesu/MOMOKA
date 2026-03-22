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

    [CreateAssetMenu(fileName = "New Vertex Program", menuName = MMKCommon.CreateMMKVertexProgramMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 100)]
    public class MMKVertexProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenu(fileName = "New Hull Program", menuName = MMKCommon.CreateMMKHullProgramMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 101)]
    public class MMKHullProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenu(fileName = "New Domain Program", menuName = MMKCommon.CreateMMKDomainProgramMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 102)]
    public class MMKDomainProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenu(fileName = "New Geometry Program", menuName = MMKCommon.CreateMMKGeometryProgramMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 103)]
    public class MMKGeometryProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenu(fileName = "New Material Program", menuName = MMKCommon.CreateMMKMaterialProgramMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 104)]
    public class MMKMaterialProgram : MMKShaderProgram
    {

    }

    [CreateAssetMenu(fileName = "New Lighting Program", menuName = MMKCommon.CreateMMKLightingProgramMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 105)]
    public class MMKLightingProgram : MMKShaderProgram
    {

    }
}
