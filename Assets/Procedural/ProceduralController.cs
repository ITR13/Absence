using UnityEngine;
using System.Collections.Generic;

namespace Abscence {
	public class ProceduralController : MonoBehaviour {
		[SerializeField]
		private GameObject[] prefabs;
		private static Stack<GameObject>[] freeObjects;

		[SerializeField]
		private float _screenVelocity;
		public static float screenVelocity;
		
		private long numberOfSpawnedObjects = 0;

		private void Awake() {
			freeObjects = new Stack<GameObject>[prefabs.Length];
			for(int i = 0; i<prefabs.Length; i++) {
				freeObjects[i] = new Stack<GameObject>();
				if(prefabs[i]==null) {
					Debug.LogWarning("Prefab at spot "+i+" does not exist");
				}else if(prefabs[i].GetComponent<GameObject>()==null) {
					Debug.LogWarning("Prefab \""+prefabs[i].name+"\" at index "+i+" does not have ProceduralObject");
				}
			}
		}

		private void Update() {
			screenVelocity = _screenVelocity;
		}

		public static void RegisterObject(GameObject o, int ID) {
			if(o!=null) {
				freeObjects[ID].Push(o);
			}
		}

		public void Spawn(int ID, Vector3 position, Quaternion rotation) {
			if(freeObjects[ID].Count==0) {
				GameObject o = (GameObject)Instantiate(prefabs[ID],position,rotation);
				o.name = "ProcGen"+numberOfSpawnedObjects++;
			} else {
				GameObject o = freeObjects[ID].Pop();
				o.transform.position = position;
				o.transform.rotation = rotation;
				o.SetActive(true);
			}
		}
	}
}