using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Abscence {
	public class ProceduralController : MonoBehaviour {
		[SerializeField]
		private static ProceduralObject[] prefabs;
		private static Stack<ProceduralObject>[] freeObjects;
		
		private void Awake() {
			freeObjects = new Stack<ProceduralObject>[prefabs.Length];
			for(int i = 0; i<prefabs.Length; i++) {
				freeObjects[i] = new Stack<ProceduralObject>();
			}
		}

		public static void RegisterObject(ProceduralObject o, int ID) {
			freeObjects[ID].Push(o);
		}

		public void Spawn(int ID, Vector3 position, Quaternion rotation) {
			if(freeObjects[ID].Count==0) {
				Instantiate(prefabs[ID],position,rotation);
			} else {
				ProceduralObject o = freeObjects[ID].Pop();
				o.transform.position = position;
				o.transform.rotation = rotation;
				o.gameObject.SetActive(true);
			}
		}
	}
}