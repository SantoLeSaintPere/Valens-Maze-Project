using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddCollider : MonoBehaviour
{
    public List<Transform> allObjs;
    public GameObject parent;

    public void FindAllObjectInChildren()
    {
        parent = gameObject;
        foreach (Transform tr in parent.GetComponentsInChildren<Transform>())
        {
            allObjs.Add(tr);
            tr.AddComponent<MeshCollider>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        FindAllObjectInChildren();
    }
}
