using UnityEngine;
using System.Collections;

namespace Abscence {
	public class LevelGenerator : MonoBehaviour {
		[SerializeField]
		private ProceduralController proceduralController;
		[SerializeField]
		private float timeBetweenEachLevel;
		[SerializeField]
		private float timer;

		[SerializeField]
		private float boxHeight;
		private float height, width;
		private int currentLevel;

		private void Awake() {
			Camera mainCamera = Camera.main;
			height = 25;
			width = 20;

			timeBetweenEachLevel = width*1.5f;
			timer = timeBetweenEachLevel;
			currentLevel = 1;
		}

		public void Update() {
			timer += Time.deltaTime*ProceduralController.screenVelocity;
			if(timer>=timeBetweenEachLevel) {
				timer -= timeBetweenEachLevel;
				GenerateLevel();
			}
		}

		private void GenerateLevel() {
			if(currentLevel<5) { //Easy levels
				int r = Random.Range(0,3);
				if(r<2) {
					Spawn(2,0,0,0);
					Spawn(2,1,0,0);
					Spawn(2,2,0,0);
					Spawn(2,3,0,0);
				}else {
					Spawn(0,0,0,0);
					Spawn(0,1,0,0);
					Spawn(0,2,0,0);
					Spawn(0,3,0,0);
				}
			}
		}

		private void Spawn(int ID,float x,float y,float d) {
			proceduralController.Spawn(ID,new Vector3(width+boxHeight*x,boxHeight*y-height/2,0),Quaternion.Euler(0,0,d));
		}
	}
}