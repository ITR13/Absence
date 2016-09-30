using UnityEngine;
using System.Collections;

namespace Abscence {
	public class TestLevelController : MonoBehaviour {
		[SerializeField]
		private ProceduralController proceduralController;
		[SerializeField]
		private float timeBetweenEachLevel;
		[SerializeField]
		private float timer;

		private float height, width;

		private void Awake() {
			Camera mainCamera = Camera.main;
			height = mainCamera.orthographicSize;
			width = mainCamera.orthographicSize*1.38f;

			timeBetweenEachLevel = width*2;
			timer = timeBetweenEachLevel;
		}

		public void Update () {
			timer += Time.deltaTime*ProceduralController.screenVelocity;
			if(timer>=timeBetweenEachLevel) {
				timer -= timeBetweenEachLevel;
				GenerateLevel();
			}
		}

		private void GenerateLevel() {
			for(int i = 0; i<20; i++) {
				proceduralController.Spawn(0,
					new Vector3(Random.Range(width,width*3),
					Random.Range(-height,height)),Quaternion.identity); 
			}
		}
	}
}