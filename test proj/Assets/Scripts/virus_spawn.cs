using UnityEngine;
using System.Collections;

public class virus_spawn : MonoBehaviour {
	public float delay; //time between spawns
	public GameObject enemy1, enemy2; //complete virus: needs a single copy to start with.
    private int speed;
    private Random rnd;
    private GameObject[] enemies;

    void Start () {
		StartCoroutine(activatePoints());
        enemies = new GameObject[] { enemy1, enemy2 };
        rnd = new Random();
        
	}

	IEnumerator activatePoints(){
        Debug.Log("Type of child array"+transform.GetType());
		foreach (Transform child in transform) {
            Debug.Log("random Enemy:"+rnd.Range((float)0,(float)2.0));
            StartCoroutine (spawnViruses(delay, child.position, child.rotation, enemy2  )    );
			yield return new WaitForSeconds (delay/transform.childCount);
		}
	}

	IEnumerator spawnViruses(float delay, Vector3 position, Quaternion rotation,GameObject enemy){
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
