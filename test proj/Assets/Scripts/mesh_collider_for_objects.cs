using UnityEngine;
using System.Collections;
using System;

public class mesh_collider_for_objects : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Debug.Log (transform.childCount);
		foreach (Transform child in transform) {
			try {
				Mesh mesh = child.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
				child.gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;
				child.GetComponent<MeshCollider>().convex = true;
			} catch (Exception e) {
				Debug.Log ("no mesh in " + child.name);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
