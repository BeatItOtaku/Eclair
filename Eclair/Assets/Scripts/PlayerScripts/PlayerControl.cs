using UnityEngine;
using System.Collections;



public class PlayerControl : MonoBehaviour
{
	


	public void setHorizontalAngle(int angle){
		h = angle;
	}

	private float angleUsing;
	private int angleId;

	public CameraController tutumin;

	private int currentHP;
	private int hp;

	public GameObject enemyObject;

	public float walkSpeed = 4.0f;
	public float runSpeed = 1.0f;
	public float sprintSpeed = 2.0f;
	public float flySpeed = 4.0f;

	public float turnSmoothing = 3.0f;
	public float aimTurnSmoothing = 15.0f;
	public float speedDampTime = 0.1f;

	public float jumpHeight = 5.0f;
	public float jumpCooldown = 1.0f;

	private float timeToNextJump = 0;
	
	private float speed;

	private Vector3 lastDirection;

	private Animator anim;
	private int speedFloat;
	private int jumpBool;
	private int hFloat;
	private int vFloat;
	private int aimBool;
	private int flyBool;
	private int groundedBool;
	private Transform cameraTransform;

	private float h;
	private float v;

	private bool aim;

	private bool run;
	private bool sprint;

	private bool isMoving = false;

	// fly
	public static bool fly = false;
	private float distToGround;
	private float sprintFactor;

	private float attackedTime =0;
	void Awake()
	{
		anim = GetComponent<Animator> ();
		cameraTransform = Camera.main.transform;

		speedFloat = Animator.StringToHash("Speed");
		jumpBool = Animator.StringToHash("Jump");
		hFloat = Animator.StringToHash("H");
		vFloat = Animator.StringToHash("V");
		aimBool = Animator.StringToHash("Aim");
		// fly
		flyBool = Animator.StringToHash ("Fly");
		groundedBool = Animator.StringToHash("Grounded");
		distToGround = GetComponent<Collider>().bounds.extents.y;
		sprintFactor = sprintSpeed / runSpeed;
		angleId = Animator.StringToHash ("AngleUsing");
	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position+ new Vector3(0,0.1f,0), -Vector3.up, distToGround + 0.5f);
	}

	void Update(){
		//CharacterController controller = GetComponent<CharacterController> ();
		if (IsGrounded())//controller.isGrounded) {
		{anim.SetBool ("NewGrounded", true);
			//transform.position += Vector3.down * 0;

		} else {
			anim.SetBool ("NewGrounded", false);
			//transform.position += Vector3.down * Time.deltaTime*10;
		}



		
		// fly
		/*if(Input.GetButtonDown ("Fly"))
			fly = !fly;
		aim = Input.GetButton("Aim");*/
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		//run = Input.GetButton ("Run");
		//sprint = Input.GetButton ("Sprint");
		isMoving = Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1;

		angleUsing = tutumin.getCameraAngle ().y;
		ShotManagament ();
		SBTManagament ();
		HPManagament();
		//KilledManagament ();


	}

		void FixedUpdate()
	{
		anim.SetBool (aimBool, IsAiming());
		anim.SetFloat(hFloat, h);
		anim.SetFloat(vFloat, v);
		
		// Fly
		anim.SetBool (flyBool, fly);
		GetComponent<Rigidbody>().useGravity = !fly;
		anim.SetBool (groundedBool, IsGrounded ());
		if(fly)
			FlyManagement(h,v);

		else
		{
			MovementManagement (h, v, run, sprint);
			JumpManagement ();
		}
	}

	private void OnCollisionEnter (Collision collider)
	{
		if(collider.gameObject.tag == "Plane")
		{ anim.SetBool ("NewGrounded", true);
		}
		else{
			anim.SetBool ("NewGrounded", false);
		}
	}



	// fly
	void FlyManagement(float horizontal, float vertical)
	{
		Vector3 direction = Rotating(horizontal, vertical);
		GetComponent<Rigidbody>().AddForce(direction * flySpeed * 100 * (sprint?sprintFactor:1));
	}

	void JumpManagement()
	{
		if (GetComponent<Rigidbody>().velocity.y < 10) // already jumped
		{
			anim.SetBool (jumpBool, false);
			if(timeToNextJump > 0)
				timeToNextJump -= Time.deltaTime;
		}
		/*if (Input.GetButtonDown ("Jump"))
		{
			anim.SetBool(jumpBool, true);
			if(speed > 0 && timeToNextJump <= 0 && !aim)
			{
				GetComponent<Rigidbody>().velocity = new Vector3(0, jumpHeight, 0);
				timeToNextJump = jumpCooldown;
			}
		}*/
	}

	void MovementManagement(float horizontal, float vertical, bool running, bool sprinting)
	{
		if (BossFootCollider.bossFootAttack == false && BossBarret.bossShotAttack == false) {
			Rotating (horizontal, vertical);
		}

		if (isMoving) {
			
			if (sprinting) {
				speed = sprintSpeed;

			} else if (running) {
				speed = runSpeed;

			} else {
				speed = walkSpeed;

			}
			anim.SetFloat (speedFloat, speed, speedDampTime, Time.deltaTime);
			if (BossFootCollider.bossFootAttack == false && BossBarret.bossShotAttack == false) {
				transform.position += transform.forward * Time.deltaTime * 5;
			}
		} else {
			speed = 0f;
			anim.SetFloat (speedFloat, 0f);
			transform.position += transform.forward * Time.deltaTime * 0;
		}

		/*		anim.SetBool ("Grounded", true); 
				transform.position += transform.forward * Time.deltaTime * 5;
			} 

		}
		if(horizontal == 0 && vertical == 0){
			anim.SetBool ("Grounded", false);
			transform.position += transform.forward * Time.deltaTime * 0;
		}*/
		GetComponent<Rigidbody>().AddForce(Vector3.forward*speed);
	}

	void ShotManagament()
	{
		if(InputManager.boltLaunch == true){
			anim.SetBool ("Shot", true);
			anim.SetFloat(angleId,angleUsing);

		}
		if(InputManager.boltLaunch == false){
			anim.SetBool("Shot",false);

		}
	}

	void SBTManagament()
	{
		if(InputManager.sbt == true){
			anim.SetBool("SBT",true);
			anim.SetFloat (angleId, angleUsing);
		}
		if(InputManager.sbt == false){
			anim.SetBool ("SBTStopToEnd", true);
			anim.SetBool ("SBT", false);
		}
	}

	void HPManagament()
	{
		if (BossFootCollider.bossFootAttack == true) { 
			GameObject bossFoot = GameObject.FindGameObjectWithTag ("Boss");
			transform.LookAt (bossFoot.transform);
			attackedTime += Time.deltaTime;
			anim.SetBool ("BigAttacked",true);
			hp = 10;
			if (attackedTime > 1.3f) {
				BossFootCollider.bossFootAttack = false;
				anim.SetBool ("BigAttacked",false);
				attackedTime = 0;
			}

		}
		if (BossBarret.bossShotAttack == true) {
			attackedTime += Time.deltaTime;
			anim.SetBool ("SmallAttacked",true);
			hp = 5;
			if (attackedTime > 0.4f) {
				BossBarret.bossShotAttack = false;
				anim.SetBool ("SmallAttacked",false);
				attackedTime = 0;
			}
		}
		currentHP -= hp;

	}

	/*void KilledManagament()
	{
		if (currentHP == 0)
		{
			anim.SetTrigger ("EclairKilled");
		}
	}*/

	Vector3 Rotating(float horizontal, float vertical)
	{
			Vector3 forward = cameraTransform.TransformDirection (Vector3.forward);
			if (!fly)
				forward.y = 0.0f;
			forward = forward.normalized;

			Vector3 right = new Vector3 (forward.z, 0, -forward.x);

			Vector3 targetDirection;

			float finalTurnSmoothing;

			if (IsAiming ()) {
				targetDirection = forward;
				finalTurnSmoothing = aimTurnSmoothing;
			} else {
				targetDirection = forward * vertical + right * horizontal;
				finalTurnSmoothing = turnSmoothing;
			}

			if ((isMoving && targetDirection != Vector3.zero) || IsAiming ()) {
				Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
				// fly
				if (fly)
					targetRotation *= Quaternion.Euler (90, 0, 0);

				Quaternion newRotation = Quaternion.Slerp (GetComponent<Rigidbody> ().rotation, targetRotation, finalTurnSmoothing * Time.deltaTime);
				GetComponent<Rigidbody> ().MoveRotation (newRotation);
				lastDirection = targetDirection;
			}
			//idle - fly or grounded
			if (!(Mathf.Abs (h) > 0.9 || Mathf.Abs (v) > 0.9)) {
				Repositioning ();
			}

			return targetDirection;
	}

	private void Repositioning()
	{
		Vector3 repositioning = lastDirection;
		if(repositioning != Vector3.zero)
		{
			repositioning.y = 0;
			Quaternion targetRotation = Quaternion.LookRotation (repositioning, Vector3.up);
			Quaternion newRotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);
			GetComponent<Rigidbody>().MoveRotation (newRotation);
		}
	}

	public bool IsFlying()
	{
		return fly;
	}

	public bool IsAiming()
	{
		return aim && !fly;
	}

	public bool isSprinting()
	{
		return sprint && !aim && (isMoving);
	}
}
