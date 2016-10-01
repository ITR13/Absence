using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SonarController : MonoBehaviour 
{
	[Range(0.025f, 2f)] public float sonarRadius = 0.5f;
	[Range(0.001f, 0.2f)] public float sonarWidth = 0.01f;

	// Use this for initialization
	void Start () 
	{
		sonarRadius = 2f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var hor = Input.GetAxis ("Horizontal");
		var ver = Input.GetAxis ("Vertical");

		//transform.position += new Vector3 (hor, ver, 0f);
		Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
		screenPos.y = 1-screenPos.y;

		Shader.SetGlobalVector("_PlayerPos", screenPos);

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			DOTween.To(value => sonarRadius = value, 0.025f, 1.5f, 3f).SetEase(Ease.InOutCubic);
		}

		Shader.SetGlobalFloat ("_Threshold", sonarWidth);
		Shader.SetGlobalFloat ("_Radius", sonarRadius);
	}
}