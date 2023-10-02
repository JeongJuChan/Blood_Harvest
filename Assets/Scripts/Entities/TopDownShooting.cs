using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpownPosition;
    private Vector2 _aimDirection = Vector2.right;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
