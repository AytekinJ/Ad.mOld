using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
	public Transform target2;
	
	public Vector3 offset; //The Z value should be -5, and it should be changed from within the game engine.
	public float smooth;  
	float smooth2 = 1f;

	bool isTargetDestroyed;
	float sayac = 5;
	Vector3 velocity = Vector3.zero;
	private void Update() {
		if(isTargetDestroyed == false)
		isTargetDestroyed = target.GetComponent<OneArmMoving>().readyToDestroy;
		else
		isTargetDestroyed = true;
	}
	void FixedUpdate()
	{
		if(isTargetDestroyed)
		{
			#region Camera Target 2 Codes
			if(target2.gameObject.transform.position.x > 30)
			{		
			Vector3 movePosition = new Vector3(30, 5, -5);
			transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth2);
			
			if(sayac < 11)
			{
				sayac += Time.deltaTime * 2f;
				gameObject.GetComponent<Camera>().orthographicSize = sayac; 
			}
			else if (sayac >= 11)
			{
				sayac = 11.01f;
			}
			}
			else
			{
			if(target2.gameObject.transform.position.x > 0)
			{
				Vector3 movePosition = target2.position + offset;
				transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
			}
			else
			{
				Vector3 movePosition = new Vector3(transform.position.x, -2, -5);
				transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
			}
			
			if(sayac > 5)
			{
				sayac-= Time.deltaTime * 3f;
				gameObject.GetComponent<Camera>().orthographicSize = sayac; 
			}
			}
			#endregion
		}
		else
		{
			#region Camera Target 1 Codes
				if(target.gameObject.transform.position.x > 30)
		{		
			Vector3 movePosition = new Vector3(30, 5, -5);
			transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth2);
			
			if(sayac < 11)
			{
				sayac += Time.deltaTime * 2f;
				gameObject.GetComponent<Camera>().orthographicSize = sayac; 
			}
			else if (sayac >= 11)
			{
				sayac = 11.01f;
			}
		}
		else
		{
			if(target.gameObject.transform.position.x > 0)
			{
				Vector3 movePosition = target.position + offset;
				transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
			}
			else
			{
				Vector3 movePosition = new Vector3(transform.position.x, -2, -5);
				transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
			}
			
			if(sayac > 5)
			{
				sayac-= Time.deltaTime * 3f;
				gameObject.GetComponent<Camera>().orthographicSize = sayac; 
			}
		}
			#endregion
		}
		
	}
}
