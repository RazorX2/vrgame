using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {
    private GameObject player;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        //transform.rotation *= Quaternion.Euler(0, 90, 0);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //transform.right = new Vector3(0, player.transform.position.y - transform.position.y, 0);
        //transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 90);

    }
}
