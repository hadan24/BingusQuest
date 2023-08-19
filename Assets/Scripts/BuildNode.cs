using UnityEngine;

public class BuildNode : MonoBehaviour
{
	public GameObject defenderPrefab;

	private GameObject defender;
	private SpriteRenderer myRend;
	private Color32 originalColor;
	private Color32 hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
		originalColor = myRend.color;
		hoverColor = new Color32(132, 219, 41, 255);
    }

	private void OnMouseDown()
	{
		if (defender != null)
			return;
		
		defender = Instantiate(defenderPrefab, transform.position, transform.rotation);
	}
	private void OnMouseEnter()
	{
		myRend.color = hoverColor;
	}

	private void OnMouseExit()
	{
		myRend.color = originalColor;
	}



	
	
	

}
