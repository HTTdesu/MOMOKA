using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MOMOKA
{
    public abstract class MMKShaderCommand
    {
        public abstract string GenterateCommandCode();
    }

    namespace ShaderCommands
    {
        public class AlphaToMask : MMKShaderCommand
        {
            public enum State
            {
                On,
                Off
            }
            public State state;

            public override string GenterateCommandCode()
            {
                return "AlphaToMask " + state.ToString();
            }
        }

        public class Blend : MMKShaderCommand
        {
            public bool SpecifyRenderTarget = false;
            public int RenderTargetIndex = 0;

            public enum State
            {
                On,
                Off
            }
            public State state;

            public enum Factor
            {
                Zero,
                One,
                SrcColor,
                OneMinusSrcColor,
                DstColor,
                OneMinusDstColor,
                SrcAlpha,
                OneMinusSrcAlpha,
                DstAlpha,
                OneMinusDstAlpha,
                SrcAlphaSaturate,
                BlendColor,
                OneMinusBlendColor
            }
            public Factor SrcFactorRGB;
            public Factor DstFactorRGB;
            public Factor SrcFactorAlpha;
            public Factor DstFactorAlpha;

            public override string GenterateCommandCode()
            {
                string result = "Blend ";
                if (SpecifyRenderTarget)
                {
                    result += $" {RenderTargetIndex}";
                }
                if (state == State.Off)
                {
                    result += " Off";
                }
                else
                {
                    result += $" {SrcFactorRGB} {DstFactorRGB} {SrcFactorAlpha} {DstFactorAlpha}";
                }
                return result;
            }
        }

        public class BlendOp : MMKShaderCommand
        {
            public enum Operation
            {
                // Basic operations - widely supported
                Add = 0,
                Sub = 1,
                RevSub = 2,
                Min = 3,
                Max = 4,

                // Logical operations - require DX 11.1+ or Vulkan
                LogicalClear = 20,
                LogicalSet = 21,
                LogicalCopy = 22,
                LogicalCopyInverted = 23,
                LogicalNoop = 24,
                LogicalInvert = 25,
                LogicalAnd = 26,
                LogicalNand = 27,
                LogicalOr = 28,
                LogicalNor = 29,
                LogicalXor = 30,
                LogicalEquiv = 31,
                LogicalAndReverse = 32,
                LogicalAndInverted = 33,
                LogicalOrReverse = 34,
                LogicalOrInverted = 35,

                // Advanced OpenGL blending operations - require GLES3.1 AEP+ or specific GL extensions
                Multiply = 40,
                Screen = 41,
                Overlay = 42,
                Darken = 43,
                Lighten = 44,
                ColorDodge = 45,
                ColorBurn = 46,
                HardLight = 47,
                SoftLight = 48,
                Difference = 49,
                Exclusion = 50,
                HSLHue = 51,
                HSLSaturation = 52,
                HSLColor = 53,
                HSLLuminosity = 54
            }
            public Operation operation;

            public override string GenterateCommandCode()
            {
                return "BlendOp " + operation.ToString();
            }
        }

        public class ColorMask : MMKShaderCommand
        {
            [Flags]
            public enum Channels
            {
                None = 0b00000000,
                R = 0b00000001,
                G = 0b00000010,
                B = 0b00000100,
                A = 0b00001000,
            }
            public Channels channels;

            public bool SpecifyRenderTarget = false;
            public int RenderTargetIndex = 0;

            public override string GenterateCommandCode()
            {
                string mask;
                if (channels == Channels.None)
                {
                    mask = "0";
                }
                else
                {
                    mask = "";
                    if (channels.HasFlag(Channels.R)) mask += "R";
                    if (channels.HasFlag(Channels.G)) mask += "G";
                    if (channels.HasFlag(Channels.B)) mask += "B";
                    if (channels.HasFlag(Channels.A)) mask += "A";
                }
                return "ColorMask " + mask + (SpecifyRenderTarget ? $" {RenderTargetIndex}" : "");
            }
        }

        public class Conservative : MMKShaderCommand
        {
            public enum Enabled
            {
                True,
                False
            }

            public Enabled enabled;

            public override string GenterateCommandCode()
            {
                return "Conservative " + enabled.ToString();
            }
        }

        public class Cull : MMKShaderCommand
        {
            public enum Mode
            {
                Off,
                Front,
                Back
            }

            public Mode mode;

            public override string GenterateCommandCode()
            {
                return "Cull " + mode.ToString();
            }
        }

        public class Offset : MMKShaderCommand
        {
            [Range(-1f, 1f)]
            public float factor = 0f;
            [Range(-1f, 1f)]
            public float units = 0f;

            public override string GenterateCommandCode()
            {
                return $"Offset {factor}, {units}";
            }
        }

        public class Stencil : MMKShaderCommand
        {
            [Range(0, 255)]
            public int Ref = 0;

            [Range(0, 255)]
            public int ReadMask = 255;
            [Range(0, 255)]
            public int WriteMask = 255;

            public bool DivideFrontAndBack = false;

            public CompareFunction Comp;
            public StencilOp Pass;
            public StencilOp Fail;
            public StencilOp ZFail;

            public CompareFunction CompFront;
            public CompareFunction CompBack;
            public StencilOp PassFront;
            public StencilOp PassBack;
            public StencilOp FailFront;
            public StencilOp FailBack;
            public StencilOp ZFailFront;
            public StencilOp ZFailBack;

            public override string GenterateCommandCode()
            {
                return DivideFrontAndBack ?
                    $"Stencil {{ Ref {Ref} ReadMask {ReadMask} WriteMask {WriteMask} CompBack {CompBack} PassBack {PassBack} FailBack {FailBack} ZFailBack {ZFailBack} CompFront {CompFront} PassFront {PassFront} FailFront {FailFront} ZFailFront {ZFailFront} }}" :
                    $"Stencil {{ Ref {Ref} ReadMask {ReadMask} WriteMask {WriteMask} Comp {Comp} Pass {Pass} Fail {Fail} ZFail {ZFail} }}";
            }
        }

        public class ZClip : MMKShaderCommand
        {
            public enum Enabled
            {
                True,
                False
            }

            public Enabled enabled;

            public override string GenterateCommandCode()
            {
                return "ZClip " + enabled.ToString();
            }
        }

        public class ZTest : MMKShaderCommand
        {
            public enum Operation
            {
                Disabled,
                Never,
                Less,
                Equal,
                LEqual,
                Greater,
                NotEqual,
                GEqual,
                Always
            }
            public Operation operation;

            public override string GenterateCommandCode()
            {
                return "ZTest " + operation.ToString();
            }
        }

        public class ZWrite : MMKShaderCommand
        {
            public enum State
            {
                On,
                Off
            }

            public State state;

            public override string GenterateCommandCode()
            {
                return "ZWrite " + state.ToString();
            }
        }

        public class GrabPass : MMKShaderCommand
        {
            // optional texture name
            public string name;

            public override string GenterateCommandCode()
            {
                if (string.IsNullOrEmpty(name))
                {
                    return "GrabPass { }";
                }
                else
                {
                    return $"GrabPass {{ \"{name}\" }}";
                }
            }
        }

        public class CustomCommand : MMKShaderCommand
        {
            public string CommandText;
            public override string GenterateCommandCode()
            {
                return CommandText;
            }
        }
    }
}
