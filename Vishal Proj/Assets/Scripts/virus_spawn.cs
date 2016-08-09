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
    private int odds;
    void Start () {
        children = new Transform[4];
        int count = 0;
        odds = 1;
        foreach (Transform child in transform)
        {
            children[count] = child;
            count++;
        }
        StartCoroutine(activatePoints());
	}
    public void changeOdds(int x)
    {
        odds = x;
    }
	IEnumerator activatePoints(){
        Debug.Log("Type of child array"+transform.GetType());
		for(int i = 0;i<4;i++) {
            StartCoroutine (spawnViruses(delay)    );
			yield return new WaitForSeconds (delay/transform.childCount);
		}
	}

	IEnumerator spawnViruses(float delay){
		while (true) {
           /*****Randomization****************/
            rperson = (int)(Random.value * 4);
            Transform child = children[rperson];
            Debug.Log("point: " + rperson);
            rperson = (int)(Random.value * 20);
            GameObject enemy = enemy1;
            if (rperson <= odds)
                enemy = enemy2;
            Debug.Log("Character:" + rperson);
            Vector3 position = child.position;
            Quaternion rotation = child.rotation;
            /*****Randomization****************/
            /*****Spawning**********************/
            GameObject nextvirus = Instantiate<GameObject> (enemy);//creates new object
            nextvirus.tag = "Enemy";//Tags it
			nextvirus.transform.position = Vector3.Scale(position,(Vector3.right+Vector3.forward));//Places it at the spawnpoint
			nextvirus.transform.rotation = rotation;//Orients it properly
			nextvirus.AddComponent<Rigidbody> ();
			nextvirus.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			nextvirus.AddComponent <virus_tracking> ();
            /*****Spawning**********************/
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
    public void TurnOn()
    {
        this.enabled = true;
    }
}
