using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public float offset = 0.707f;
    public Vector3 lastPos;
    

    private int roadCount = 0;

    public void Startbuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
        
    }
 

    public void CreateNewRoadPart()
    {
        Debug.Log("Create new road part");
        Vector3 spawnPos=Vector3.zero;

        float change = Random.Range(0, 100);
        if (change < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);

        GameObject g= Instantiate(roadPrefab,spawnPos,Quaternion.Euler(0,45,0));
        lastPos = g.transform.position;

        roadCount++;
        if (roadCount % 5 == 0) 
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }

    // Update is called once per frame
  
}
