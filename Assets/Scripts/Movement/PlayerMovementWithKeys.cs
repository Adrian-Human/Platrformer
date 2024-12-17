using Interfaces;
using UnityEngine;

namespace Movement
{
	public class PlayerMovementWithKeys : MonoBehaviour
	{
		[SerializeField] private float speed;
		[SerializeField] private float jumpForce;
		[SerializeField] private LayerMask groundLayer;
		[SerializeField] private Transform groundCheck;
		[SerializeField] private float groundCheckRadius = 0.2f;

		private IMoveVelocity _moveVelocity;
		private IJump _jumpComponent;
		private Rigidbody2D _rb;
		private float _dirX;
		private bool _isGrounded;

		private void Start()
		{
			_moveVelocity = GetComponent<IMoveVelocity>();
			_jumpComponent = GetComponent<IJump>();
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			_dirX = Input.GetAxisRaw("Horizontal");

			_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

			if (Input.GetButtonDown("Jump") && _isGrounded)
			{
				Debug.Log("Got here");
				Jump();
			}
		}

		private void FixedUpdate()
		{
			_moveVelocity.SetVelocity(new Vector3(_dirX, _rb.velocity.y).normalized * speed);
		}

		private void Jump()
		{
			_jumpComponent.Jump(Vector3.up * jumpForce);
		}
	}
}
