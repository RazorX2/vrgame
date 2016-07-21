using UnityEngine;
using System.Collections;
using System;

public class mesh_collider_for_objects : MonoBehaviour {

	// generates colliders for every subobject on start
	void Start () {
//		Debug.Log (transform.childCount);
		foreach (Transform child in transform) {
			try {
				Mesh mesh = new Mesh();
				try{
					mesh = child.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
				} catch(Exception e){
//					Debug.Log(child.name + "is mesh filter");
				}
				try{
					mesh = child.gameObject.GetComponent<MeshFilter>().sharedMesh;
				} catch(Exception e){
//					Debug.Log(child.name + "is skinned mesh");
				}
				if(mesh.vertexCount < 1){
					continue;
				}
				child.gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;
				child.GetComponent<MeshCollider>().convex = true;
			} catch (Exception e) {
//				Debug.Log ("no mesh in " + child.name);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
