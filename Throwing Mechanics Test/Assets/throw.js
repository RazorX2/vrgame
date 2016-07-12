#pragma strict

var mc : GameObject; // The main camera
var g: boolean = true; // Gravity
var canShoot: boolean = false;
var justShot: boolean = false;
var cc : CharacterController; // The player

function Start () {}

 function Update()
 {
 	var distance: float;
 	distance = Vector3.Distance(mc.transform.position, GetComponent.<Rigidbody>().transform.position);

	if(distance < 8 && !canShoot && !justShot /*|| Input.GetKey("n") && !canShoot && !justShot*/)
    {
     	g = false; // turns the gravity on
        canShoot = true;
         // If the player is close enough by the sphere and he didn't just shot, the sphere will be picked up.
         // If the justShot boolean wouldn't be there, you would pick up the sphere immediataly after shooting and you
         // could not throw it.
    }

 	if(g)
 	{
 		GetComponent.<Rigidbody>().AddForce(Physics.gravity * GetComponent.<Rigidbody>().mass); // gravity
 	}

     if(canShoot)
     {
     	transform.position = mc.transform.position + mc.transform.forward*2; // teleports the sphere in front of the player
     	GetComponent.<Rigidbody>().velocity = Vector3.zero; 		   // Sets the velocity
     	GetComponent.<Rigidbody>().angularVelocity = Vector3.zero; // and the rotation of the sphere to zero (rotation is not necessary if you work with a shere).
     }

     if(Input.GetKey("b") && canShoot)
     {
     	g = true;
        GetComponent.<Rigidbody>().AddForce(mc.transform.forward * 1500); // shoot
        canShoot = false;
        justShot = true;
     }

     if(justShot && distance > 8)
     {
     justShot=false; // reset the justShot boolean, if the sphere is far enough
     }
 }
