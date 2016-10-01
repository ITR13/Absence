using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;

namespace Abscence {
	public class BasicController : MonoBehaviour {
		[SerializeField]
		PlatformerCharacter2D controller;
		[SerializeField]
		Animator animator;
		private float jumpTimer;

		void OnCollisionEnter2D(Collision2D other) {
			if(other.gameObject.layer==9) {
				Die();
			}
		}

		public void Die() {
			//animation.
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		void FixedUpdate() {
			float move = Input.GetAxis("Horizontal");
			bool crouch = Input.GetKey(KeyCode.LeftShift);
			jumpTimer -= Time.deltaTime;
			if(Input.GetKeyDown(KeyCode.Space)) {
				jumpTimer = 0.2f;
			}

			controller.Move(move,ProceduralController.screenVelocity,crouch, jumpTimer>=0);
		}
	}
}