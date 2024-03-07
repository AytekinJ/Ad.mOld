using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Camera : MonoBehaviour
{
    public Transform target;
	Vector3 offset; //The Z value should be -5, and it should be changed from within the game engine.
    Vector3 velocity = Vector3.zero;
	public float smooth;  
    private void FixedUpdate() {
        try
        {
            if(target.transform.position.x > -2.5 && target.transform.position.x < 30)
            {
                Vector3 movePosition = new Vector3(target.position.x, transform.position.y, -5);
		        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
            }
            else if(target.transform.position.x < -2.5)
            {
                Vector3 movePosition = new Vector3(0, transform.position.y, -5);
		        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
            }
            else if(target.transform.position.x > 30)
            {
                Vector3 movePosition = new Vector3(30, transform.position.y, -5);
		        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
            }
            
        }
        catch
        {

        }
		
        
    }
}
