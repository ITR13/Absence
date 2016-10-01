using UnityEngine;
using System.Collections;

namespace Abscence {
	public class MovingPlatform : MonoBehaviour {
		[SerializeField]
		private float timerSwitch;
		private float timer;
		[SerializeField]
		private float direction;
		private float _direction;

		private void OnEnable() {
			_direction = direction;
			timer = 0;
		}

		public void Update() {
			transform.position += Vector3.right*_direction*Time.deltaTime;
			timer += Time.deltaTime;
			if(timer>timerSwitch) {
				timer = timerSwitch-timer;
				_direction = -_direction;
			}
		}
	}
}