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
    private int spawnNum;

	private int initSpawn = 0;
//	public bool bossSpawned = false;
    void Start () {
        spawnNum = transform.childCount;
		//Debug.Log (spawnNum);
        children = new Transform[spawnNum];
        int count = 0;
        odds = 1;
        foreach (Transform child in transform)
        {
            children[count] = child;
            count++;
        }
//        StartCoroutine(activatePoints());
		//StartCoroutine(spawnViruses(delay/spawnNum));
	}
    public void changeOdds(int x)
    {
        odds = x;
    }
//	IEnumerator activatePoints(){
//		while (initSpawn < 5) {
//			Debug.Log ("points activated");
//			StartCoroutine (spawnViruses (delay));
//			initSpawn++;
//			yield return new WaitForSeconds (delay / spawnNum);
//		}
//////		for(int i = 0;i<spawnNum;i++) {
//////			Debug.Log ("points activated");
//////            StartCoroutine (spawnViruses(delay));
//////			//yield return new WaitForSeconds (delay/spawnNum);
//////			yield new WaitForSeconds(delay/spawnNum);
//////		}
//	}

	IEnumerator spawnViruses(float delay){
		while (true) {
            /*****Randomization****************/
            Debug.Log("Spawned one");
            rperson = (int)(Random.value * spawnNum);
            Transform child = children[rperson];
            //Debug.Log("point: " + rperson);
            rperson = (int)(Random.value * 90);
            GameObject enemy = enemy1;
			if (rperson <= odds) {
				enemy = enemy2;
//				bossSpawned = true;
			}
            //Debug.Log("Character:" + rperson);
            Vector3 position = child.position;
            Quaternion rotation = child.rotation;
            /*****Randomization****************/
            /*****Spawning**********************/
            GameObject nextvirus = Instantiate<GameObject> (enemy);//creates new object
            nextvirus.tag = "Enemy";//Tags it
			nextvirus.transform.position = Vector3.Scale(position,(Vector3.right+Vector3.forward));//Places it at the spawnpoint
			nextvirus.transform.rotation = rotation;//Orients it properly
			//nextvirus.AddComponent<Rigidbody> ();
            nextvirus.GetComponent<Rigidbody>().useGravity = true;
			nextvirus.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			nextvirus.AddComponent <virus_tracking> ();
//			if (bossSpawned)
//				transform.gameObject.SetActive (false);
            /*****Spawning**********************/
            yield return new WaitForSeconds (delay);
		}
	}
	// Update is called once per frame
	void Update () {

	}
    public void TurnOff()
    {
        StopAllCoroutines();
        enabled = false;
    }
    public void TurnOn()
    {
		StartCoroutine(spawnViruses(delay/spawnNum));
        enabled = true;
    }
}
