using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerJuice : MonoBehaviour {

    public float DestroyTime = 0.5f;
    public float CreationTime = 1f;

    private MeshRenderer meshRenderer;
    private Color emission;

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        emission = meshRenderer.material.GetColor("_EmissionColor");
        meshRenderer.material.SetColor("_EmissionColor", Color.black);

        FadeIn();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void FadeIn()
    {
        meshRenderer.material.DOBlendableColor(emission, "_EmissionColor", CreationTime);
    }

    public void FadeOut()
    {
        meshRenderer.material.DOBlendableColor(Color.black, "_EmissionColor", DestroyTime);
    }
}
