using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
	private CharacterController character;
	private Vector3 direction;

	public float jumpForce = 8f;
	public float gravity = 9.81f * 2f;

	private void Awake()
	{
		character = GetComponent<CharacterController>();
	}

	private void OnEnable()
	{
		direction = Vector3.zero;
	}

	private void Update()
	{
		direction += Vector3.down * gravity * Time.deltaTime;

		if (character.isGrounded)
		{
			direction = Vector3.down;

			if (Input.GetKeyDown(KeyCode.Space))
			{
				direction = Vector3.up * jumpForce;
			}
		}

		character.Move(direction * Time.deltaTime);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Obstacle"))
		{
			FindObjectOfType<GameManager>().GameOver();
			//GameManager.Instance.GameOver();
		}
	}
}







/*
public class Player : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	public float Jump;
	bool isJumping = false;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			rb.AddForce(Vector2.up * Jump);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			bool isJumping = false;

		}

	}
}
*/