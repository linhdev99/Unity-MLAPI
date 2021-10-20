using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Radom = UnityEngine.Random;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    Material[] m_matColor;
    [SerializeField]
    MeshRenderer meshRenderer;
    void Start()
    {
        int indexColor = Random.Range(0,100) % 4;
        meshRenderer.material = m_matColor[indexColor];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
