using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOMOKA.Shader
{
    public enum MMKShaderInjectPoint
    {
        BeforeInclude,
        AfterInclude,
        BeforePass,
        AfterPass,
    }

    public enum ShaderPropertyDeclarationType
    {
        Global,
        PerMaterial
    }

    public class MMKShaderCommon
    {
        public enum Precision
        {
            Lowp,
            Mediump,
            Highp,
        }

        public static Precision precision = Precision.Highp;

        public static string GetPrecisionForFloat()
        {
            switch (precision)
            {
                case Precision.Lowp:
                    return "half";
                case Precision.Mediump:
                    return "fixed";
                default:
                case Precision.Highp:
                    return "float";
            }
        }
    }
}
