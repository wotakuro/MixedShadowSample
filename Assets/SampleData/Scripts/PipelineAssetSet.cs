using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;

public class PipelineAssetSet : MonoBehaviour {
    public RenderPipelineAsset asset;
	// Use this for initialization
	void Start () {
        GraphicsSettings.renderPipelineAsset = asset;
	}
	
}
