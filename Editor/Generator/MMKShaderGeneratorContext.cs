using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOMOKA.MetaData;

namespace MOMOKA.Generator
{
    public class MMKShaderGeneratorContext
    {
        public string ShaderPath;
        public string ShaderUniformPath;
        public string ShaderLibraryPath;

        public string ShaderName;
        public string ShaderFallback;
        public string ShaderEditor;

        public List<string> ShaderProperties = new List<string>();

        public List<MMKShaderPassGenerator> ShaderPasses = new List<MMKShaderPassGenerator>();
    }
}
