using UnityEngine;

public class CastleWall : MonoBehaviour
{
	public int maxHP = 100;
	public int HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

	public void TakeDamage(int taken)
	{
		HP -= taken;
		if (HP < 0)
			print("Floppa has taken over the town!!");
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
