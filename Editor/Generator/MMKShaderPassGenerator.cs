using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOMOKA.Generator
{
    public class MMKShaderPassGenerator
    {
        public string PassName;
        public Dictionary<string, string> Tags;
        public Dictionary<string, string> Commands;
        public List<string> Macros;

        public StringBuilder Code = new StringBuilder();
    }
}
