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
			height = 13.8f*2;
			width = 20;

			timeBetweenEachLevel = 3;
			timer = timeBetweenEachLevel;
			currentLevel = 1;
			closedPaths = 0;
		}

		public void Update() {
			timer += Time.deltaTime*ProceduralController.screenVelocity;
			if(timer>=timeBetweenEachLevel) {
				timer -= timeBetweenEachLevel;
				GenerateLevel();
			}
		}

		int closedPaths;
		private void GenerateLevel() {
			int nextPath = closedPaths;
			for(int i = -1; i<11; i++) {
				if(i==-1||(closedPaths&1<<i)!=0) {
					if(((closedPaths&2<<i)!=0) ||
						(i!=-1&&(nextPath&closedPaths&1<<i)!=0)){
						continue;
					}
					if((closedPaths&4<<i)!=0){
							if(Random.Range(0,1)==0) {
							nextPath -= 4<<i;
							}else if(i!=-1&&Random.Range(0,1)==0) {
							nextPath -= 1<<i;
						}
					}else {
						if(i!=-1) {
							int r = Random.Range(0,11);
							if(r==0) {
								nextPath -= 1<<i;
							}else if(r==1) {
								nextPath += 2<<i;
							}else if(r==2||r==3) {
								nextPath += 4<<i;
							}else if(r==4||r==5) {
								nextPath += 6<<i;
							}else if(r==6||r==7||r==8||r==9) {
								nextPath += 8<<i;
							}
						}else {
							int r = Random.Range(0,6);
							if(r==0) {
								nextPath += 1;
								Debug.Log("!!!");
							}else if(r==1) {
								nextPath += 2;
							}else if(r==2) {
								nextPath += 3;
							}else if(r==3||r==4) {
								nextPath += 4;
							}
						}
					}
				}
			}
			Debug.Log(closedPaths+", "+nextPath);


			closedPaths = nextPath%(1<<12);
			for(int i = 0; i<12; i++) {
				if((closedPaths&1<<i)!=0) {
					for(int j = i; j<6; j++) {
						if((closedPaths&1<<j)==0) {
							int diff = j-i;
							if(diff==1) {
								Spawn(0,0,i,0);
							}else if(diff==2) {
								Spawn(2,0,i,0);
							}else if(diff==3) {
								Spawn(3,0,i,0);
							}else if(diff==4) {
								Spawn(4,0,i,0);
							}
							i = j;
							break;
						}
					}
				}
			}
		}

		private void Spawn(int ID,float x,float y,float d) {
			proceduralController.Spawn(ID,new Vector3(width+boxHeight*x,boxHeight*y-height/2,0),Quaternion.Euler(0,0,d));
		}
	}
}