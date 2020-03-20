using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject o;

    GameObject[] _gs;
    const int MAX_COUNT = 1000;

    // Start is called before the first frame update
    void Start()
    {
        Physics.autoSimulation = false;
        Physics.autoSyncTransforms = false;
        _gs = new GameObject[MAX_COUNT];
        for (int i = 0; i < MAX_COUNT; i++)
        {
            _gs[i] = GameObject.Instantiate(o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 2 == 1)
        {
            Physics.Simulate(0.1f);
        }

        for (int i = 0; i < MAX_COUNT; i++)
        {
            _gs[i].transform.SetPositionAndRotation(new Vector2(Random.Range(0, 100), Random.Range(0, 100)), Quaternion.LookRotation(new Vector2(Random.Range(0, 100), Random.Range(0, 100)), new Vector2(Random.Range(0, 100), Random.Range(0, 100))));
        }
    }

    private void LateUpdate()
    {
        if (Time.frameCount % 2 == 0)
        {
            Physics.SyncTransforms();
        }
    }
}
