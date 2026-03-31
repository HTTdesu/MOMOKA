using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MOMOKA.MetaData
{
    [CreateAssetMenu(fileName = "New Pass", menuName = MMKCommon.CreateMMKShaderPassMenuItem, order = MMKCommon.AssetsMenuRootDevBaseOrder + 2)]
    public class MMKShaderPass : ScriptableObject
    {
        public string PassName;
        public string LightMode;
        public string[] Tags;
        public MMKShaderCommand[] Commands;

        public MMKShaderPassFrame PassFrame;
        public MMKShaderFeature[] DefaultFeatures;
    }
}
