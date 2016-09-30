using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

namespace Abscence {
	public class BasicController : MonoBehaviour {
		[SerializeField]
		PlatformerCharacter2D controller;

		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		void FixedUpdate() {
			float move = Input.GetAxis("Horizontal");
			bool crouch = !Input.GetKey(KeyCode.LeftShift);
			bool jump = Input.GetKey(KeyCode.Space);
			controller.Move(move,crouch, jump);
		}
	}
}