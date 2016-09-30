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

		private void OnBecameInvisible() {
			if(wasVisible) {
				ProceduralController.RegisterObject(this,objectID);
				gameObject.SetActive(false);
			}
		}

		private void OnBecameVisible() {
			wasVisible = true;
		}
	}
}