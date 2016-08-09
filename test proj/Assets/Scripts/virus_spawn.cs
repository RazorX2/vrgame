using UnityEngine;
using System.Collections;

public class virus_spawn : MonoBehaviour {
	public float delay; //time between spawns
	public GameObject enemy1, enemy2; //complete virus: needs a single copy to start with.
    private int speed;
    private Random rnd;
    private GameObject[] enemies;
    private Transform[] children;
    private int rperson;
    private GameObject enemy;
    void Start () {
        children = new Transform[4];
        int count = 0;
        enemies = new GameObject[] { enemy1, enemy2 };
        rnd = new Random();

        foreach (Transform child in transform)
        {
            children[count] = child;
            count++;
        }
        StartCoroutine(activatePoints());
	}

	IEnumerator activatePoints(){
        Debug.Log("Type of child array"+transform.GetType());
		for(int i = 0;i<4;i++) {
            rperson = (int)(Random.value*4);
            Transform child = children[rperson];
            Debug.Log(rperson);
            rperson = (int)(Random.value*10);
            enemy = enemy1;
            if (rperson == 1)
                enemy = enemy2;
            Debug.Log(rperson);
            Debug.Log("");
            StartCoroutine (spawnViruses(delay, child.position, child.rotation, enemy  )    );
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
