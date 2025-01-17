using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class player_movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform character ;
    [SerializeField] private float jumforce = 10f;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform feetpos;
    [SerializeField] private float grounddistance = 0.25f;
    [SerializeField] private float jumptime = 0.3f;
    [SerializeField] private float crouchheight = 0.5f;
    private bool isgrounded = false;
    private bool isjumping = false;
    private float jumptimer ;
    private void Update(){
        isgrounded = Physics2D.OverlapCircle(feetpos.position,grounddistance,groundlayer);
        #region jumping
        if(isgrounded && Input.GetButtonDown("Jump")){
            isjumping = true;
            rb.linearVelocity = Vector2.up * jumforce;
        }

        if(isjumping && Input.GetButton("Jump")){
            if(jumptimer < jumptime){
                rb.linearVelocity = Vector2.up * jumforce;
                jumptimer += Time.deltaTime;
            } else {
                isjumping = false;
            }

        }
        if(Input.GetButtonUp("Jump")){
            isjumping = false;
            jumptimer = 0;
        }
        #endregion
        
        #region crouching
        if(isgrounded && Input.GetButton("Crouch")){
            character.localScale = new Vector3(character.localScale.x, crouchheight, character.localScale.z);
            if(isjumping){
                character.localScale = new Vector3(character.localScale.x, 1f,character.localScale.z);
            }
        }
        if(Input.GetButtonUp("Crouch")){
            character.localScale = new Vector3(character.localScale.x, 1f,character.localScale.z);
        }
        #endregion
    }


}
