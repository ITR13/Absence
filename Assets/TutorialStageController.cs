using UnityEngine;
using System.Collections;

namespace Abscence {
	public class TutorialStageController : MonoBehaviour {
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
			Debug.Log("Spawning level "+currentLevel+"!");
			if(currentLevel==0) {
				Spawn(0,1,0,0);
				Spawn(0,2,0,0);
				Spawn(0,2,1,0);
				Spawn(0,3,0,0);
				Spawn(0,3,1,0);
				Spawn(0,4,0,0);
				Spawn(0,4,1,0);
				Spawn(0,5,0,0);
			}else if(currentLevel==1) {
				Spawn(0,1,0,0);
				Spawn(0,2,0,0);
				Spawn(0,2,1,0);
				Spawn(1,3,0,0);
				Spawn(0,4,0,0);
				Spawn(0,4,1,0);
				Spawn(0,5,0,0);
			}else if(currentLevel==2) {
				for(int i = 1;i<7;i++) {
					Spawn(0,i,2,0);
					Spawn(0,i,3,0);
					Spawn(0,i,4,0);
				}
				Spawn(0,1,1,0);
				Spawn(0,2,1,0);
				Spawn(1,4,1,0);
				Spawn(1,5,1,0);
				Spawn(0,6,1,0);
			}else if(currentLevel==3) {
				for(int i = 0; i<9; i++) {
					Spawn(0,i,0,0);
				}
				Spawn(1,1,1,0);
				Spawn(1,4,1,0);
				Spawn(1,5,1,0);
				Spawn(1,6,1,0);
				Spawn(1,7,1,0);
			}else if(currentLevel==4) {
				for(float i = 1.5f; i<9; i++) {
					Spawn(0,0,i,0);
				}
				Spawn(0,1,1.5f,0);
				Spawn(0,2,1.5f,0);
				Spawn(0,3,1.5f,0);
				Spawn(0,2,4,0);
				Spawn(0,3,4,0);
				Spawn(0,4,4,0);
				Spawn(0,5,4,0);
				Spawn(0,5,0,0);
				Spawn(0,5,1,0);
				Spawn(0,5,2,0);
				Spawn(0,5,3,0);
			}


			currentLevel++;
		}

		private void Spawn(int ID, float x, float y, float d) {
			proceduralController.Spawn(ID,new Vector3(width+boxHeight*x,boxHeight*y-height/2,0),Quaternion.Euler(0,0,d));
		}
	}
}