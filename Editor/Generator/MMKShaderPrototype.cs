using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOMOKA.MetaData;

namespace MOMOKA.Generator
{
    public class MMKShaderPrototype : ScriptableObject
    {
        public List<MMKShaderCodeSnap> ShaderCode = new List<MMKShaderCodeSnap>();

        public bool Validate()
        {
            // TODO: validate shader code
            return true;
        }
    }
}
