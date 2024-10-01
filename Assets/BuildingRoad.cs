using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRoad : MonoBehaviour {

    public Transform prefab;
    int counter = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter % 4 == 0)
            {
                Instantiate(prefab, new Vector3(1, 0, counter), Quaternion.identity);
                counter++;
            }
            else
            {
                Instantiate(prefab, new Vector3(0, 0, counter), Quaternion.identity);
                counter++;
            }
            
        }
    }
}