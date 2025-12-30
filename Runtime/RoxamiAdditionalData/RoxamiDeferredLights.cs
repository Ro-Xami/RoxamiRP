using UnityEngine.Rendering.Universal.Internal;

namespace UnityEngine.Rendering.Universal
{
    public abstract class RoxamiDeferredLights
    {
        public abstract bool NeedToExecute();

        public abstract void InitializeAdditionalLightsData(ref RenderingData renderingData, AdditionalLightsShadowCasterPass shadowCasterPass);
        
        public abstract void Execute(ScriptableRenderContext context, CommandBuffer commandBuffer, ref RenderingData renderingData);

        public virtual void Dispose()
        {
            
        }

        protected void ExecuteCommandBuffer(ScriptableRenderContext context, CommandBuffer commandBuffer)
        {
            context.ExecuteCommandBuffer(commandBuffer);
            commandBuffer.Clear();
        }
    }
}