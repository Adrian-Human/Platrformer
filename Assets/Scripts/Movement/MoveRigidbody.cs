using Interfaces;
using UnityEngine;

namespace Movement
{
	public class MoveRigidbody : MonoBehaviour, IMoveVelocity, IJump
	{
		private Rigidbody2D _rb;

		private void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		public void SetVelocity(Vector3 velocity)
		{
			_rb.velocity = velocity;
		}

		public void Jump(Vector3 jumpVelocity)
		{
			_rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
		}
	}
}
