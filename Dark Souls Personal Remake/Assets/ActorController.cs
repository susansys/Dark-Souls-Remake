using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour {

	public GameObject model;
	public PlayerInput pi;
	public float walkSpeed = 1.4f; 

	[SerializeField] 
	private Animator anim;
	private Rigidbody rigid;
	private Vector3 movingVec;


	// Use this for initialization
	void Awake () {
		pi = GetComponent<PlayerInput> ();
		anim = model.GetComponent<Animator>	();
		rigid = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {	//Time.deltaTime 1/60
		//print (pi.Dup);
		anim.SetFloat("forward", pi.Dmag);
		if (pi.Dmag > 0.1f){
		model.transform.forward = pi.Dvec;
		}
		movingVec = pi.Dmag * model.transform.forward * walkSpeed;
	}

	void FixedUpdate(){		//TIme.FixedDeltaTime 1/50
		//rigid.position += movingVec * Time.fixedDeltaTime;
		rigid.velocity = new Vector3(movingVec.x, rigid.velocity.y ,movingVec.z);

	}
}
