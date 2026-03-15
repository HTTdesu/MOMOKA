using MOMOKA.Shader;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MOMOKA.MetaData
{
    public abstract class MMKShaderCodeSnap : ScriptableObject
    {
        public MMKShaderInjectPoint InjectPoint;
        public MMKShaderBinding Binding;

        public abstract string GenerateCode();
    }

    [CreateAssetMenuAttribute(fileName = "New File Shader Code", menuName = MMKCommon.CreateMMKFileShaderCodeSnapMenuItem, order = 200)]
    public class MMKFileShaderCodeSnap : MMKShaderCodeSnap
    {
        public TextAsset CodeFile;
        public override string GenerateCode()
        {
            return CodeFile.text;
        }
    }

    [CreateAssetMenuAttribute(fileName = "New String Shader Code", menuName = MMKCommon.CreateMMKStringShaderCodeSnapMenuItem, order = 200)]
    public class MMKStringShaderCodeSnap : MMKShaderCodeSnap
    {
        [TextArea(5, 10)]
        public string CodeString;
        public override string GenerateCode()
        {
            return CodeString;
        }
    }
}
