using UnityEngine;
using System.Collections;

namespace Abscence {
	public class MovingPlatform : MonoBehaviour {
		[SerializeField]
		private float timerSwitch;
		private float timer;
		[SerializeField]
		private float direction;

		private void OnEnable() {
			timer = 0;
		}

		public void Update() {
			transform.position += Vector3.right*direction*Time.deltaTime;
			timer += Time.deltaTime;
			if(timer>timerSwitch) {
				timer = timerSwitch-timer;
				direction = -direction;
			}
		}
	}
}