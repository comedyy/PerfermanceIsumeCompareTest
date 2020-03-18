using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject obj_prefab;
    public Transform parent;
    public bool use_parent;

    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        CreateEntities(2000, obj_prefab, parent);

        btn.onClick.AddListener(()=> {
            for (int i = 0; i < _arr_trans.Length; i++)
            {
                _arr_trans[i].SetParent(null);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
        Vector3 Pos1 = new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
        Quaternion q = Quaternion.FromToRotation(Pos, Pos1);

        for (int i = 0; i < _arr_trans.Length; i++)
        {
            _arr_trans[i].transform.SetPositionAndRotation(Pos, q);
        }
    }

    Transform[] _arr_trans;
    void CreateEntities(int count, GameObject prefab, Transform parent)
    {
        _arr_trans = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            _arr_trans[i] = GameObject.Instantiate(prefab, parent).transform;
        }
    }
}
