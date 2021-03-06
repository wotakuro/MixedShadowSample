// Autogenerated file. Do not edit by hand
using System;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering
{
    public class GPUCopy
    {
        ComputeShader m_Shader;
        int k_SampleKernel_xyzw2x;

        public GPUCopy(ComputeShader shader)
        {
            m_Shader = shader;
            k_SampleKernel_xyzw2x = m_Shader.FindKernel("KSampleCopy4_1_x");
        }

        static readonly int _Result1 = Shader.PropertyToID("_Result1");
        static readonly int _Source4 = Shader.PropertyToID("_Source4");
        public void SampleCopyChannel_xyzw2x(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier target, Vector2 size)
            {
                cmd.SetComputeTextureParam(m_Shader, k_SampleKernel_xyzw2x, _Source4, source);
                cmd.SetComputeTextureParam(m_Shader, k_SampleKernel_xyzw2x, _Result1, target);
                cmd.DispatchCompute(m_Shader, k_SampleKernel_xyzw2x, (int)Mathf.Max((size.x) / 8, 1), (int)Mathf.Max((size.y) / 8, 1), 1);
            }

    }
}
