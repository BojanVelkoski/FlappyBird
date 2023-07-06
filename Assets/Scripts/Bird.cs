using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float gravity = -9.8f;
    public float strength = 5f; //Kolku silno da letnuva pri sekoj klik

    private void OnEnable(){
        Vector3 position=transform.position;
        position.y=0;
        transform.position=position;
        direction=Vector3.zero;
    }

    private void Awake(){
        spriteRenderer=GetComponent<SpriteRenderer>();   
    }

    private void Start(){
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void AnimateSprite(){
        spriteIndex++;
        if(spriteIndex>=sprites.Length){
            spriteIndex=0;
        }
        spriteRenderer.sprite=sprites[spriteIndex];
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction=Vector3.up * strength;
        }
        direction.y+=gravity * Time.deltaTime;
        transform.position+=direction *Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Obstacle"){
            FindObjectOfType<GameSystem>().GameOver();
        }else if(collider.gameObject.tag=="Scoring"){
            FindObjectOfType<GameSystem>().increaseScore();
        }
    }
}
