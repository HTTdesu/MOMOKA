using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOMOKA
{
    public static class MMKCommon
    {
        public const string AssetsMenuRoot = "MOMOKA/";
        public const int AssetsMenuRootBaseOrder = -100;

        public const string CreateMMKShaderGroupOrchestratorMenuItem = AssetsMenuRoot + "Generate Shader Group";
        public const string CreateMMKShaderOrchestratorMenuItem = AssetsMenuRoot + "Generate Shader";

        public const string AssetsMenuRootDev = AssetsMenuRoot + "Developer/";
        public const int AssetsMenuRootDevBaseOrder = -100;

        public const string CreateMMKShaderGroupMenuItem = AssetsMenuRootDev + "Create Shader Group";
        public const string CreateMMKShaderMenuItem = AssetsMenuRootDev + "Create Shader";
        public const string CreateMMKShaderPassMenuItem = AssetsMenuRootDev + "Create Shader Pass";
        public const string CreateMMKShaderFeatureMenuItem = AssetsMenuRootDev + "Create Shader Feature";

        public const string CreateMMKVertexProgramMenuItem = AssetsMenuRootDev + "Create Vertex Program";
        public const string CreateMMKHullProgramMenuItem = AssetsMenuRootDev + "Create Hull Program";
        public const string CreateMMKDomainProgramMenuItem = AssetsMenuRootDev + "Create Domain Program";
        public const string CreateMMKGeometryProgramMenuItem = AssetsMenuRootDev + "Create Geometry Program";
        public const string CreateMMKMaterialProgramMenuItem = AssetsMenuRootDev + "Create Material Program";
        public const string CreateMMKLightingProgramMenuItem = AssetsMenuRootDev + "Create Lighting Program";

        public const string CreateMMKFileShaderCodeSnapMenuItem = AssetsMenuRootDev + "Create File Shader Code";
        public const string CreateMMKStringShaderCodeSnapMenuItem = AssetsMenuRootDev + "Create String Shader Code";
    }
}