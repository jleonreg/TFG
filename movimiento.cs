using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public CharacterController controller;
    Vector3 playerInput;
    public float speed;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    void Update()
    {
        controlMovimiento();
    }

    private void controlMovimiento(){

        Vector3 movimiento  = Vector3.zero;

        movimientoMovil();

        movimiento = playerInput * speed * Time.deltaTime;

        controller.Move(movimiento);
        controller.transform.LookAt(controller.transform.position + movimiento);
    }

    private void movimientoMovil(){
        float horizontal=0;
        float vertical=0;
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            switch (touch.phase){
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    touchEndPos = touch.position;
                    Vector2 touchDelta = touchEndPos - touchStartPos;

                    if (touchDelta.magnitude > 10f){
                        if (Mathf.Abs(touchDelta.x) > Mathf.Abs(touchDelta.y)){
                            vertical = touchDelta.y;
                        }
                        else{
                            horizontal = touchDelta.x;
                        }
                    }

                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    // Resetear variables u hacer algo al finalizar el toque
                    horizontal = 0;
                    vertical = 0;
                    break;
            }
        }

        playerInput = new Vector3(horizontal, 0, vertical);
        playerInput  = Vector3.ClampMagnitude(playerInput, 1);
    }
}
