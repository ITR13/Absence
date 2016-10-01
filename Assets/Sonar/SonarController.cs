using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SonarController : MonoBehaviour 
{
	[Range(0.025f, 2f)] public float sonarRadius = 0.5f;
	[Range(0.001f, 0.2f)] public float sonarWidth = 0.01f;
	private float sonarTimer;

	// Use this for initialization
	void Start () 
	{
		sonarRadius = 2f;
		sonarTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var hor = Input.GetAxis ("Horizontal");
		var ver = Input.GetAxis ("Vertical");

		//transform.position += new Vector3 (hor, ver, 0f);
		Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

		Shader.SetGlobalVector("_PlayerPos", screenPos);

		sonarTimer -= Time.deltaTime;
		if (Input.GetKey(KeyCode.E)&&sonarTimer<=0) {
			DOTween.To(value => sonarRadius = value, 0.025f, 1.5f, 5f).SetEase(Ease.OutCubic);
			sonarTimer = 1.2f;
		}

		Shader.SetGlobalFloat ("_Threshold", sonarWidth);
		Shader.SetGlobalFloat ("_Radius", sonarRadius);
	}


	


}