using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody thisRigidBody = null;
    private Animation thisAnimation;
    public int score;
    public Text txtscore;

    public static Player thisPlayer;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        thisRigidBody = GetComponent<Rigidbody>();
        thisPlayer = this;
    }

    void Update()
    {
        txtscore.text = "Score : " + score;
        if (transform.position.y < 3.7f)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisRigidBody.AddForce(Vector3.up * 350);
                thisAnimation.Play();
            }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 3.7f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene(1);
        }
        
        if (other.tag == "Score")
        {
            Destroy(other.gameObject);
            score++;
        }
    }

    public void AddScore()
    {
        score++;
    }
}
