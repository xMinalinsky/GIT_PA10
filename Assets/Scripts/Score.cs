using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -8)
        {
            Destroy(gameObject);
        }
        else
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
    }
}
