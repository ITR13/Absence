using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Abscence {
	public class ProceduralObject : MonoBehaviour{
		[SerializeField]
		private int objectID;
		private bool wasVisible;
		private void OnAwake() {
			wasVisible = false;
		}

		public void Update() {
			transform.position -= Vector3.right*Time.deltaTime*ProceduralController.screenVelocity;
		}

		private void OnBecameInvisible() {
			if(wasVisible) {
				ProceduralController.RegisterObject(gameObject,objectID);
				gameObject.SetActive(false);
			}
		}

		private void OnBecameVisible() {
			wasVisible = true;
		}
	}
}