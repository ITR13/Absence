using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SonarController : MonoBehaviour 
{
	[Range(0.05f, 2f)] public float sonarRadius = 0.5f;
	[Range(0.001f, 0.05f)] public float sonarWidth = 0.01f;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		var hor = Input.GetAxis ("Horizontal");
		var ver = Input.GetAxis ("Vertical");

		transform.position += new Vector3 (hor, ver, 0f);

		Shader.SetGlobalVector("_PlayerPos", Camera.main.WorldToViewportPoint(transform.position));

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			DOTween.To(value => sonarRadius = value, 0.05f, 1.5f, 10f).SetEase(Ease.OutCubic);
		}

		Shader.SetGlobalFloat ("_Threshold", sonarWidth);
		Shader.SetGlobalFloat ("_Radius", sonarRadius);
	}
}