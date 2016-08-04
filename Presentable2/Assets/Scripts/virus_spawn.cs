using UnityEngine;
using System.Collections;

public class virus_spawn : MonoBehaviour {
	public float delay; //time between spawns
	public GameObject enemy; //complete virus: needs a single copy to start with.
    private int speed;

	void Start () {
		StartCoroutine(activatePoints());
	}

	IEnumerator activatePoints(){
        Debug.Log(transform);
		foreach (Transform child in transform) {
			StartCoroutine (spawnViruses (delay, child.position, child.rotation));
			yield return new WaitForSeconds (delay/transform.childCount);
		}
	}

	IEnumerator spawnViruses(float delay, Vector3 position, Quaternion rotation){
		while (true) {
			GameObject nextvirus = Instantiate<GameObject> (enemy);
			nextvirus.transform.position = Vector3.Scale(position,(Vector3.right+Vector3.forward));
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
    public void TurnOff()
    {
        this.enabled = false;
    }
}
