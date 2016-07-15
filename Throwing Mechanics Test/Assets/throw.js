#pragma strict

//var mc : GameObject; // The main camera
var g: boolean = false;
GetComponent. < Rigidbody > ().useGravity = false; // Gravity
var canShoot: boolean = false;
var justShot: boolean = false;
var cc: CharacterController; // The player

function Start() {}

function Update() {
    {
        var distance: float;
        distance = Vector3.Distance(cc.transform.position, GetComponent. < Rigidbody > ().transform.position);

        if (Input.GetKey("p") && !canShoot && !justShot) {
            canShoot = true;
            transform.position = cc.transform.position + Vector3.up + Vector3.back;
            // If the player is close enough by the sphere and he didn't just shot, the sphere will be picked up.
            // If the justShot boolean wouldn't be there, you would pick up the sphere immediataly after shooting and you
            // could not throw it.
        }

        // if (g) {
        //     GetComponent. < Rigidbody > ().AddForce(Physics.gravity * GetComponent. < Rigidbody > ().mass); // gravity
        // }

        // if (canShoot &&  !justshot) {
        //     transform.position = cc.transform.position + cc.transform.forward * 2; // teleports the sphere in front of the player
        //     GetComponent. < Rigidbody > ().velocity = Vector3.one; // Sets the velocity
        //     GetComponent. < Rigidbody > ().angularVelocity = Vector3.one*10; // and the rotation of the sphere to zero (rotation is not necessary if you work with a shere).
        // }

        if (Input.GetKey("b") && canShoot) {
            print("I made It");
            g = true;
            GetComponent. < Rigidbody > ().AddForce(cc.transform.up * 10 + cc.transform.forward * 10, ForceMode.Impulse);
            GetComponent. < Rigidbody > ().useGravity = true;
            GetComponent. < Rigidbody > ().angularVelocity = Vector3.one * 5; // shoot
            canShoot = false;
            justShot = true;
        }

        if (transform.position.y < .1 && justShot) {
            justShot = false;
            GetComponent. < Rigidbody > ().angularVelocity = Vector3.zero;
            GetComponent. < Rigidbody > ().velocity = Vector3.zero;
            GetComponent. < Rigidbody > ().useGravity = false; // reset the justShot boolean, if the sphere is far enough
        }

    }
}
