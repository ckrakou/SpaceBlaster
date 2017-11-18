using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleJuice : MonoBehaviour {

    public float SpawnTime;
    public float DestroyTime;

	// Use this for initialization
	void Start () {
        Vector3 scale = transform.localScale;
        transform.localScale = Vector3.zero;
        Color transparent = GetComponentInChildren<MeshRenderer>().material.color;
        transparent.a = 0;
        GetComponentInChildren<MeshRenderer>().material.color = transparent;

        Sequence spawnAnimation = DOTween.Sequence();
        spawnAnimation.Append(transform.DOScale(scale, SpawnTime));
        spawnAnimation.Append(GetComponentInChildren<MeshRenderer>().material.DOFade(1, SpawnTime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Remove()
    {
        GetComponentInChildren<MeshCollider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().material.DOFade(0, DestroyTime);
        Destroy(this.gameObject, DestroyTime);
    }
}
