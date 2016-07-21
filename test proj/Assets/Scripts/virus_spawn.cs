using UnityEngine;
using System.Collections;

public class virus_spawn : MonoBehaviour {
	public float delay; //time between spawns
	public GameObject virus; //complete virus: needs a single copy to start with.

	void Start () {
		StartCoroutine(activatePoints());
	}

	IEnumerator activatePoints(){
		foreach (Transform child in transform) {
			StartCoroutine (spawnViruses (delay, child.position, child.rotation));
			yield return new WaitForSeconds (1f);
		}
	}

	IEnumerator spawnViruses(float delay, Vector3 position, Quaternion rotation){
		while (true) {
			GameObject nextvirus = Instantiate<GameObject> (virus);
			nextvirus.transform.position = position;
			nextvirus.transform.rotation = rotation;
			nextvirus.AddComponent<Rigidbody> ();
			nextvirus.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			nextvirus.AddComponent <virus_tracking> ();
			yield return new WaitForSeconds (delay);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
