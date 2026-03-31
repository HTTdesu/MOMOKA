using System;
using System.Linq;
using System.Text;
using UnityEngine;
using MOMOKA.Shader;
using System.Collections.Generic;

namespace MOMOKA.MetaData
{
    [Serializable]
    public abstract class MMKShaderProperty
    {
        public ShaderPropertyDeclarationType ShaderDeclaration = ShaderPropertyDeclarationType.PerMaterial;

        public bool EditorOnly;

        public string[] Header;
        public string PropertyName;
        public string PropertyDescription;
        public string ConstantBufferName;

        public abstract string GenerateMaterialProperty();

        public abstract string GenerateShaderUniform();

        protected string ComposeHeader(string[] extreHeaders = null)
        {
            HashSet<string> allHeaders = new HashSet<string>(Header ?? Array.Empty<string>());
            if (extreHeaders != null)
            {
                foreach (string header in extreHeaders)
                {
                    allHeaders.Add(header);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string header in allHeaders)
            {
                if (!header.StartsWith("["))
                {
                    sb.Append("[");
                }
                sb.Append(header);
                if (!header.EndsWith("]"))
                {
                    sb.Append("]");
                }
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }

    public class MMKShaderPropertyFloat : MMKShaderProperty
    {
        public float DefaultValue;

        public override string GenerateMaterialProperty()
        {
            return $"{ComposeHeader()}{PropertyName} (\"{PropertyDescription}\", Float) = {DefaultValue}";
        }

        public override string GenerateShaderUniform()
        {
            if (EditorOnly)
            {
                return null;
            }
            else
            {
                return $"{MMKShaderCommon.GetPrecisionForFloat()} {PropertyName};";
            }
        }
    }

    public class MMKShaderPropertyRange : MMKShaderPropertyFloat
    {
        public float RangeMin;
        public float RangeMax;

        public override string GenerateMaterialProperty()
        {
            return $"{ComposeHeader()}{PropertyName} (\"{PropertyDescription}\", Range({RangeMin}, {RangeMax})) = {DefaultValue}";
        }

        public override string GenerateShaderUniform()
        {
            if (EditorOnly)
            {
                return null;
            }
            else
            {
                return $"{MMKShaderCommon.GetPrecisionForFloat()} {PropertyName};";
            }
        }
    }

    public class MMKShaderPropertyInt : MMKShaderProperty
    {
        public int DefaultValue;

        public override string GenerateMaterialProperty()
        {
            return $"{ComposeHeader()}{PropertyName} (\"{PropertyDescription}\", Integer) = {DefaultValue}";
        }

        public override string GenerateShaderUniform()
        {
            if (EditorOnly)
            {
                return null;
            }
            else
            {
                return $"{MMKShaderCommon.GetPrecisionForFloat()} {PropertyName};";
            }
        }
    }

    public class MMKShaderPropertyVector : MMKShaderProperty
    {
        public Vector4 DefaultValue;

        public override string GenerateMaterialProperty()
        {
            return $"{ComposeHeader()}{PropertyName} (\"{PropertyDescription}\", Vector) = ({DefaultValue.x}, {DefaultValue.y}, {DefaultValue.z}, {DefaultValue.w})";
        }

        public override string GenerateShaderUniform()
        {
            if (EditorOnly)
            {
                return null;
            }
            else
            {
                return $"{MMKShaderCommon.GetPrecisionForFloat()}4 {PropertyName};";
            }
        }
    }

    public class MMKShaderPropertyColor : MMKShaderProperty
    {
        public Color DefaultColor;
        public bool HDR;

        public override string GenerateMaterialProperty()
        {
            return $"{ComposeHeader(new string[] { HDR ? "HDR" : "" })}{PropertyName} (\"{PropertyDescription}\", Color) = ({DefaultColor.r}, {DefaultColor.g}, {DefaultColor.b}, {DefaultColor.a})";
        }

        public override string GenerateShaderUniform()
        {
            if (EditorOnly)
            {
                return null;
            }
            else
            {
                return $"{MMKShaderCommon.GetPrecisionForFloat()}4 {PropertyName};";
            }
        }
    }

    public class MMKShaderPropertyTexture : MMKShaderProperty
    {
        public enum TextureDimension
        {
            Texture2D,
            Texture2DArray,
            Texture3D,
            TextureCube,
            TextureCubeArray
        }

        public enum TextureDefault
        {
            white,
            black,
            gray,
            bump,
            red
        }

        public TextureDimension Dimension;
        public TextureDefault DefaultTexture;
        public bool UseScaleAndOffset;
        public bool NoSampler;

        public override string GenerateMaterialProperty()
        {
            string dimensionStr = Dimension switch
            {
                TextureDimension.Texture2D => "2D",
                TextureDimension.Texture2DArray => "2DArray",
                TextureDimension.Texture3D => "3D",
                TextureDimension.TextureCube => "Cube",
                TextureDimension.TextureCubeArray => "CubeArray",
                _ => "2D"
            };

            string valueStr = Dimension switch
            {
                TextureDimension.Texture2D => $"\"{DefaultTexture.ToString()}\"",
                _ => "\"\""
            };

            return $"{ComposeHeader(new string[] { UseScaleAndOffset ? "" : "NoScaleOffset" })}{PropertyName} (\"{PropertyDescription}\", {dimensionStr}) = {valueStr} {{}}";
        }

        public override string GenerateShaderUniform()
        {
            if (EditorOnly) return null;

            string dimensionStr = Dimension switch
            {
                TextureDimension.Texture2D => "TEXTURE2D",
                TextureDimension.Texture2DArray => "TEXTURE2D_ARRAY",
                TextureDimension.Texture3D => "TEXTURE3D",
                TextureDimension.TextureCube => "TEXTURECUBE",
                TextureDimension.TextureCubeArray => "TEXTURECUBE_ARRAY",
                _ => "TEXTURE2D"
            };

            string textureStatement = $"{dimensionStr}({PropertyName});";
            string samplerStatement = NoSampler ? null : $"SAMPLER(sampler_{PropertyName});";
            string scaleOffsetStatement = UseScaleAndOffset ? $"float4 {PropertyName}_ST;" : null;

            return string.Join(Environment.NewLine, new[] { textureStatement, samplerStatement, scaleOffsetStatement }.Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}
