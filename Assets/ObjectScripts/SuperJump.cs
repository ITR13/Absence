using UnityEngine;
using System.Collections;

namespace Abscence {
	public class SuperJump : MonoBehaviour {
		[SerializeField]
		private float force = 900;

		public void OnCollisionEnter2D(Collision2D other) {
			if(other.gameObject.tag=="Player") {
				other.rigidbody.AddForce(Vector3.up*force);
			}
		}
	}
}