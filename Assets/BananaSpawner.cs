using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BananaSpawner: MonoBehaviour
{
 	Sprite[] sprites;
   	List<GameObject> gameobjects;
   	int numberOfGameObjects = 0;
   	Rigidbody rb;
   	public Vector3 lastMousePos;
   	public Vector3 mouseUpPos;

   	// GameObject force;
	public BananaSpawner(Sprite[] sprites) {
		this.sprites = sprites;
		this.gameobjects = new List<GameObject>();
		// force = new GameObject("force");
		// force.AddComponent<Rigidbody2D>();

	}

	void Start() {
		Debug.Log("Start BananaSpawner");
		rb = GetComponent<Rigidbody>();
		lastMousePos = Input.mousePosition;
	}

    public void SpawnFood(string  typeOfFood) {
		if (typeOfFood == "food") {
			// Vector2Int foodGridPosition = new Vector2Int(Random.Range(-50,50), Random.Range(-50,50));

			for(int index = 0; 
				index < sprites.Length; 
				index++) {
				Debug.Log(sprites[0].name);

			}

			//create a gameobject, food
			string name = $"Food{numberOfGameObjects.ToString()}";
			numberOfGameObjects++;
			GameObject foodGameObject = new GameObject(name, typeof(SpriteRenderer));

			//get each sprite from the array set the sprite renderers sprite to it
	    	foodGameObject.GetComponent<SpriteRenderer>().sprite = sprites[0] as Sprite;

	    	// //scale it so it is small enough
	    	foodGameObject.transform.localScale = new Vector3((float)3,(float)3,1);

	    	// //position it at top of camera view
	    	foodGameObject.transform.position = new Vector3(0,6);

	    	//programmatically add box collider and rigid body
	    	foodGameObject.AddComponent<BoxCollider2D>();
	 		foodGameObject.AddComponent<Rigidbody2D>();
	 		foodGameObject.layer = LayerMask.NameToLayer("fruit");
	 		// foodGameObject.AddComponent<Rigidbody>();

            // foodGameObject.AddComponent(typeof(EventTrigger));
            // EventTrigger trigger = foodGameObject.GetComponent<EventTrigger>();
            // EventTrigger.Entry entry = new EventTrigger.Entry();
            // entry.eventID = EventTriggerType.PointerDown;
            // entry.callback.AddListener( (eventData) => { 
            //     Debug.Log("Event Click");
            //     OnPointerDownDelegate((PointerEventData)eventData);
            //     // Debug.Log(eventData);

            // });
            // trigger.triggers.Add(entry);

            gameobjects.Add(foodGameObject);



		} 

	}

	public void checkTap() {
		foreach(GameObject obj in gameobjects) {
			if (obj != null) {

			    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	           	// BoxCollider2D coll = obj.GetComponent<BoxCollider2D>();

	            // if(coll.OverlapPoint(wp)) {
	            // 	Debug.Log(Input.mousePosition);
	            //     Debug.Log($"Point clicked sprite {obj.name}");
					// Destroy(obj);
	                // rb.AddForce(obj.transform.forward * 1600f);
	                // mouseEnterPos = Input.mousePosition;
	                // detectSwipeDirection(obj);


	            // }
	        }
		}
	}

	public void detectSwipeDirection(GameObject obj) {
		detectDirectionY(obj);
		lastMousePos = Input.mousePosition;
	}

	public void detectDirectionY(GameObject obj) {
		if (Input.mousePosition.y > lastMousePos.y)
        {
            Debug.Log("You dragged up!");
			detectDirectionX(obj);

        } else if (Input.mousePosition.y < lastMousePos.y)
        {
        	detectDirectionX(obj);
            Debug.Log("You dragged down!");
        }
	}

	public void detectDirectionX(GameObject obj) {
	    if (Input.mousePosition.x > lastMousePos.x) {
        	obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(2,5), ForceMode2D.Impulse);
        } else {
        	obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2,5), ForceMode2D.Impulse);
        }
	}

	public void OnPointerDownDelegate( PointerEventData data )
    {
    	Debug.Log("OnPointerDownDelegate called.");
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		 Debug.Log("Left click");
		else if (eventData.button == PointerEventData.InputButton.Middle)
		 Debug.Log("Middle click");
		else if (eventData.button == PointerEventData.InputButton.Right)
		 Debug.Log("Right click");
	}



    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
    }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    // }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Mouse Up");
    }
}
