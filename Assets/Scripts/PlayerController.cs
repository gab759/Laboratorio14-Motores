using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _compAudioSource;
    [SerializeField] private Rigidbody _compRigidbody;
    [SerializeField] private float velocity;
    private bool booleano = false;
    public bool interactiveNPC = false;
    private Vector2 movement;
    void Start()
    {
        _compAudioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {   
        _compRigidbody.velocity = new Vector3(movement.x, _compRigidbody.velocity.y, movement.y);
    }
    private void Update()
    {
        PlaySoundMovement();
    }

    private void PlaySoundMovement()
    {
        if (booleano == true)
        {
            if (!_compAudioSource.isPlaying)
            {
                _compAudioSource.Play();
            }
        }
        else
        {
            _compAudioSource.Stop();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Door"))
        {
            SceneManager.LoadScene("Escene2");
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>() * velocity;
        if (movement.magnitude > 0)
        {
            booleano = true;
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            interactiveNPC = true;
        }else if (context.canceled)
        {
            interactiveNPC = false;
        }
    }
}
