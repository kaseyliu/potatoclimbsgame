using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingBarScript : MonoBehaviour
{

    [SerializeField] Transform topPivot; 
    [SerializeField] Transform botPivot; 
    [SerializeField] Transform Good; 

    [SerializeField] Transform cursor; 
    float cursorPosition; 
    float cursorDestination; 
    
    float cursorSpeed = 1f; 
    [SerializeField] float smoothMotion = 1f; 
    private bool move = true; 




    private void Update(){
        CursorMove(); 
        PlayerStop(); 
    }

    void CursorMove(){
        if (move){
        cursorPosition = Mathf.Clamp01(cursorPosition + Time.deltaTime * cursorSpeed * smoothMotion);
        Vector3 Toppest = new Vector3(topPivot.position.x, topPivot.position.y + (topPivot.position.y/2), 
                            topPivot.position.z);
        Vector3 Bottom = new Vector3(botPivot.position.x, botPivot.position.y + (botPivot.position.y/2), 
                            botPivot.position.z);
        cursor.position = Vector3.Lerp(Toppest, Bottom, cursorPosition);

        if (cursorPosition >= 1f || cursorPosition <= 0f)
        {
            cursorSpeed *= -1f;
        }
        }
    }

    void PlayerStop(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cursor.position.y < Good.position.y + (Good.localScale.y / 2) &&
                    cursor.position.y > Good.position.y - (Good.localScale.y / 2))
            {
                Debug.Log("good");
            }
            else
            {
                Debug.Log("Bad");
                
            }
                move = false; 
        }
    }


    
    // void CursorMove(){
    //     cursorTimer -= Time.deltaTime; 
    //     if (cursorTimer < 0f){
    //         cursorTimer = UnityEngine.Random.value * timerMult; 
    //         cursorDestination = UnityEngine.Random.value; 
    //     }

    //     cursorPosition = Mathf.SmoothDamp(cursorPosition, cursorDestination, ref cursorSpeed, smoothMotion); 
    //     cursor.position = Vector3.Lerp(botPivot.position, topPivot.position, cursorPosition); 
    // }
    
}
