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

			timeBetweenEachLevel = 2.5f*5f;
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

		private void GenerateLevel() {
			int r = Random.Range(0,9);
			if(r==0||r==1) {
				Spawn4x4(0,currentLevel/15);
				Spawn4x4(2,currentLevel/15);
			}else if(r==2||r==3) {
				Spawn4x4(1,currentLevel/15);
				Spawn4x4(0,currentLevel/15);
			}
			else if(r==4||r==5) {
				Spawn4x4(1,currentLevel/15);
				Spawn4x4(2,currentLevel/15);
				Spawn(Random.Range(0,3),-1,0,0);
			}
			else if(r==6||r==7) {
				Spawn4x4(2,currentLevel/20);
				Spawn(Random.Range(0,3),-1,0,0);
			}
			else {
				Spawn4x4(1,currentLevel/15);
				Spawn4x4(2,currentLevel/15);
				Spawn4x4(3,currentLevel/15);
				//Spawn(Random.Range(0,3),-1,0,0);
			}


			if(currentLevel<80) {
				currentLevel++;
				Debug.Log(currentLevel/20);
			}
		}


		private void Spawn4x4(int y, int danger) {
			int r = Random.Range(0,7);
			if(r==0) {
				if(danger==0) {
					Spawn(0,0+y,y*4,0);
					Spawn(0,1+y,y*4,0);
					Spawn(0,2+y,y*4,0);
					Spawn(0,3+y,y*4,0);
				} else {
					Spawn(Random.Range(0,5-danger)==0 ? 1 : 0,0+y,y*4,0);
					Spawn(Random.Range(0,5-danger)==0 ? 1 : 0,1+y,y*4,0);
					Spawn(Random.Range(0,5-danger)==0 ? 1 : 0,2+y,y*4,0);
					Spawn(Random.Range(0,5-danger)==0 ? 1 : 0,3+y,y*4,0);
				}
			}else if(r==1) {
				Spawn(0,0+y,y*4,0);
				Spawn(0,1+y,y*4,0);
				Spawn(0,2+y,y*4,0);
				Spawn(0,3+y,y*4,0);
				if(danger==0) {
					Spawn(0,1+y,y*4+2,0);
					Spawn(0,2+y,y*4+2,0);
					Spawn(0,3+y,y*4+2,0);
				}else {
					Spawn(Random.Range(0,5-danger)==0 ? 1 : 0,1+y,y*4+2,0);
					Spawn(Random.Range(0,5-danger)==0 ? 1 : 0,2+y,y*4+2,0);
					Spawn(Random.Range(0,5-danger)==0 ? 1 : 0,3+y,y*4+2,0);
				}
			}else if(r==2) {
				Spawn(0,0+y,y*4,0);
				Spawn(2,1+y,y*4,0);
				Spawn(3,2+y,y*4,0);
				Spawn(4,3+y,y*4,0);
				if(danger==1) {
					int dangerous = Random.Range(0,danger);
					for(int i = 0; i<danger; i++) {
						int p = Random.Range(0,4);
						Spawn(1,p+y,p+1,0);
					}
				}
			}else if(r==3) {
				Spawn(5,0+y,y*4+1,0);
				Spawn(5,1+y,y*4+1,0);
				Spawn(5,2+y,y*4+1,0);
				Spawn(5,3+y,y*4+1,0);
			}else if(r==4) {
				Spawn(6,Random.Range(1,3),0,0);
			}else if(r==5) {
				Spawn(7,Random.Range(1,3),0,0);
			}else if(r==6) {
				Spawn(0,0,y*4,0);
				Spawn(2,2,y*4,0);
			}
		}

		// Not working
		int closedPaths;
		int spikesSpawned;
		private void GenerateTopPath(bool spawnSpikes) {
			int nextPath = closedPaths;
			for(int i = -1;i<11;i++) {
				if(i==-1||(closedPaths&1<<i)!=0) {
					if(((closedPaths&2<<i)!=0) ||
						(i!=-1&&(nextPath&closedPaths&1<<i)!=0)) {
						continue;
					}
					if((closedPaths&4<<i)!=0) {
						if(Random.Range(0,1)==0) {
							nextPath -= 4<<i;
						}
						else if(i!=-1&&Random.Range(0,1)==0) {
							nextPath -= 1<<i;
						}
					}
					else {
						if(i!=-1) {
							int r = Random.Range(0,11);
							if(r==0) {
								nextPath -= 1<<i;
							}
							else if(r==1) {
								nextPath += 2<<i;
							}
							else if(r==2||r==3) {
								nextPath += 4<<i;
							}
							else if(r==4||r==5) {
								nextPath += 6<<i;
							}
							else if(r==6||r==7||r==8||r==9) {
								nextPath += 8<<i;
							}
						}
						else {
							int r = Random.Range(0,6);
							if(r==0) {
								nextPath += 1;
							}
							else if(r==1) {
								nextPath += 2;
							}
							else if(r==2) {
								nextPath += 3;
							}
							else if(r==3||r==4) {
								nextPath += 4;
							}
						}
					}
				}
			}

			closedPaths = nextPath%(1<<12);
			for(int i = 0;i<12;i++) {
				if((closedPaths&1<<i)!=0) {
					for(int j = i;j<6;j++) {
						if((closedPaths&1<<j)==0) {
							int diff = j-i;
							if(diff==1) {
								Spawn(0,0,i,0);
							}
							else if(diff==2) {
								Spawn(2,0,i,0);
							}
							else if(diff==3) {
								Spawn(3,0,i,0);
							}
							else if(diff==4) {
								Spawn(4,0,i,0);
							}
							i = j;
							break;
						}
					}
				}
			}

			if(spawnSpikes) {
				if(spikesSpawned==-1) {
					spikesSpawned = Random.Range(0,5);
				}else if(spikesSpawned==0) {
					if(Random.Range(0,3)==0) {
						spikesSpawned = Random.Range(0,5);
					}
				}else if(spikesSpawned-->1) {
					for(int i = 5;i>=0;i--) {
						if(i==0||(closedPaths&(1<<(i-1)))!=0) {
							Spawn(1,0,i,0);
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