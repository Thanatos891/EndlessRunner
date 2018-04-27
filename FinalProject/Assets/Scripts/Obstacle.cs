using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public ObstacleCubeData oc;


    public int objLength;
    public int objWidth;
    public int objHeight;
    public Material objMaterial;

    public GameObject obstacleToSpawn;
    public GameObject g;
  

	// Use this for initialization
	void Start () {
        this.oc = Resources.Load<ObstacleCubeData>("Obstacle1");
        g = Instantiate(Resources.Load<GameObject>("Cube"));
        objLength = oc.length;
        objWidth = oc.width ;
        objHeight = oc.height;
        objMaterial = oc.obstacleColor;

        obstacleToSpawn.transform.localScale += new Vector3(objLength, 0 ,objWidth);
    }
}
