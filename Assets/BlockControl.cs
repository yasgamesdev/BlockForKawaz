using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour {
	void Start () {
        CreateBlocks();
    }

    void CreateBlocks()
    {
        Transform parent = GameObject.Find("Blocks").transform;

        Vector3 start_pos = new Vector3(-4.0f, 0, 5.0f);
        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                GameObject block = (GameObject)Instantiate(Resources.Load("Block"), parent);
                block.transform.position = start_pos + new Vector3(2.0f * x, 0, 1.0f * z);
            }
        }
    }
}
