using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCharacterScript : MonoBehaviour
{

    public CharacterController _controller;
    public float _speed = 10;
    public float _rotationSpeed = 180;

    private Vector3 rotation;

    public int maxHealth;
    public int currentHealth;
    public HealthBar healthbar; 

    public void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth); 
    }

    public void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10); 
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth); 
    }


}

