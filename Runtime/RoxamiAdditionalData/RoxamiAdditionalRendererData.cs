using System;
using UnityEngine;

namespace UnityEngine.Rendering.Universal
{
    [Serializable]
    public abstract class RoxamiAdditionalRendererData : ScriptableObject
    {
        private RoxamiDeferredLights m_RoxamiDeferredLights;
        internal RoxamiDeferredLights deferredLights => m_RoxamiDeferredLights;

        public abstract RoxamiDeferredLights CreateDeferredRenderPass();

        void m_SetDirty()
        {
            UniversalRenderPipelineAsset asset = (UniversalRenderPipelineAsset)GraphicsSettings.renderPipelineAsset;
            if (!asset || asset.m_RendererDataList == null || asset.m_RendererDataList.Length < 0) return;
            foreach (var renderer in asset.m_RendererDataList)
            {
                if (!renderer) continue;
                renderer.SetDirty();
            }
        }

        private void OnEnable()
        {
            m_RoxamiDeferredLights = CreateDeferredRenderPass();

            m_SetDirty();
        }

        private void OnValidate()
        {
            m_RoxamiDeferredLights = CreateDeferredRenderPass();

            m_SetDirty();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Called by Dispose().
        /// Override this function to clean up resources in your renderer.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            m_RoxamiDeferredLights?.Dispose();
        }
        
    }
}