using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Mover al personaje
        rig.velocity = new Vector2(horizontal, vertical) * velocidad;

        // Cambiar la animación según la velocidad
        float velocidadActual = rig.velocity.magnitude;
        anim.SetFloat("Walk", Mathf.Abs(velocidadActual));

        // Girar el sprite dependiendo del movimiento horizontal
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true; // Mirar hacia la izquierda
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false; // Mirar hacia la derecha
        }
    }
}