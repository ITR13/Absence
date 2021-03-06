﻿using UnityEngine;
using System.Collections;

namespace Abscence {
	public class KillParentIfTouched : MonoBehaviour {
		public void OnCollisionEnter2D(Collision2D other) {
			if(other.gameObject.tag=="Player") {
				transform.parent.position -= Vector3.up*40;
				other.rigidbody.AddForce(Vector3.up*400);
			}
		}
	}
}