using UnityEngine;
using System.Collections;

namespace Abscence {
	public class FallingPlatform : MonoBehaviour {
		[SerializeField]
		private float acceleration;
		[SerializeField]
		private Rigidbody2D rigidbody;

		private void OnEnable() {
			rigidbody.gravityScale = 0;
		}

		private void OnCollisionEnter2D(Collision2D other) {
			rigidbody.gravityScale = acceleration;
		}
	}
}