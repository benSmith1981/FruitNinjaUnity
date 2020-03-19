using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;

public class GameHandler : MonoBehaviour
{
/*	public Sprite marbleSprite;
    public Sprite bananasSprite;*/
    
    // Start is called before the first frame update
    private float pressTimer;
    private float pressTimerMax;
    private BananaSpawner foodSpawner;
    public Sprite[] sprites;
    private List<GameObject> gameobjects;

    void Start()
    {
        foodSpawner = new BananaSpawner(sprites);

    }

     public void OnPointerDownDelegate( PointerEventData data )
     {
     }
    private void Awake() {
        pressTimerMax = 0.1f;
        pressTimer = pressTimerMax; 
    }
    // Update is called once per frame
    void Update()
    {
        pressTimer += Time.deltaTime;

        //when all the delta times reach max update position
        if(pressTimer > pressTimerMax) { 
            // Debug.Log("gridMoveTimer > gridMoveTimerMax***********");
            pressTimer -= pressTimerMax; //reset to zero
            if (Input.GetKey(KeyCode.RightArrow))
    		{
    			foodSpawner.SpawnFood("food");
    		} 
            if (Input.GetMouseButtonDown(0))
            {
                // foodSpawner.mouseDownPos = Input.mousePosition;
                Debug.Log($"GetMouseButtonDown {Input.mousePosition}");
            }
            if (Input.GetMouseButtonUp (0))
            {
                // foodSpawner.mouseUpPos = Input.mousePosition;
                Debug.Log($"GetMouseButtonUP {Input.mousePosition}");


            }
            foodSpawner.checkTap();
        }
		// else if (Input.GetKey(KeyCode.LeftArrow))
		// {
		// 	SpawnFood("marble");
		// }
    }


}
