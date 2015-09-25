using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	[HideInInspector] public bool jump;

	public static float moveSpeed = 5f;
	public static float jumpSpeedInitial = 20f;
	public static float g = 90;
	public Transform groundCheck;

	private bool isGrounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private float currentYVelocity = 0;

	public Ground GroundPrefab;
	private Ground[] groundList;
	private const int GroundCount = 35;
	private int frontGroundIndex = 0;
	private const int MaximumfrontGroundDistance = 17;

	private const float Timestep = 0.02f;
	private int count;
	// Use this for initialization

	void Awake(){
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		jump = false;
		groundList = new Ground[GroundCount];

		for (int i = 0; i < GroundCount; i++) {
			GenerateGround (i);
		}
	}
	// Update is called once per frame
	void Update () {
		isGrounded = transform.position.y <= 0;
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			jump = true;
			currentYVelocity = 0;
			isGrounded = false;
		}

		RollGround ();
	}

	void FixedUpdate()
	{
		anim.SetFloat ("Speed", 1);

		if (jump) {
			anim.SetTrigger("Jump");
			currentYVelocity = jumpSpeedInitial;
			jump = false;
		}

		if (isGrounded == false) {
			currentYVelocity += -g * Timestep;
		}

		if (transform.position.y + currentYVelocity * Timestep <= 0) {
			isGrounded = true;
			transform.position += new Vector3 ( moveSpeed * Timestep, -transform.position.y, 0);
			currentYVelocity = 0;
		} else {
			transform.position += new Vector3 (moveSpeed * Timestep, currentYVelocity * Timestep, 0);
		}
		/*
		count++;
		if (count == 674) {
			count = 0;
			Debug.Log (transform.position.x);
		}*/
	}

	void GenerateGround(int index)
	{
		groundList[index] = (Ground)Instantiate (GroundPrefab, new Vector3(index, -1, 0), Quaternion.identity);
	}

	void RollGround()
	{
		if (groundList [frontGroundIndex].transform.position.x + MaximumfrontGroundDistance < transform.position.x) {
			groundList [frontGroundIndex].transform.position += new Vector3 (GroundCount, 0, 0);
			++frontGroundIndex;
			if(frontGroundIndex >= GroundCount)
			{
				frontGroundIndex = 0;
			}
			RollGround ();
		}
	}
}
