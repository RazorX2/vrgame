using UnityEngine;
using System.Collections;

public class virus_spawn : MonoBehaviour {
	public float delay; //time between spawns
	public GameObject enemy; //complete virus: needs a single copy to start with.
    private int speed;
	private int rperson;
	private Transform[] children;

	void Start () {
        children = new Transform[4];
        int count = 0;
        foreach (Transform child in transform)
        {
            children[count] = child;
            count++;
        }
        StartCoroutine(activatePoints());
		
	}

	IEnumerator activatePoints(){
        //Debug.Log(transform);
		for(int i = 0;i<4;i++) {
			rperson = (int)(Random.value*4);
            //Debug.Log(rperson);
            Transform child = children[i];
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
