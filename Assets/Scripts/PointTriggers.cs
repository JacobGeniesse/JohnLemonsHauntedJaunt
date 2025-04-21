using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTriggers : MonoBehaviour
{
	public Points points;
    public Transform player;
	void OnTriggerEnter(Collider other){
		if(other.transform == player){
			points.addPoints(100);
			Destroy(this.gameObject);
		}
	}
}
