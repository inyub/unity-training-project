using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathActivation : MonoBehaviour
{
    public List<PathMediator> _pathes = new List<PathMediator>();

    void Start()
     {
        for (int i = 0; i < transform.childCount; i++)
        {
            _pathes.Add(transform.GetChild(i).gameObject.GetComponent<PathMediator>());
        }

    }

}
