using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineController : MonoBehaviour
{

    [SerializeField] GameObject[] bullets;
 
    public static bool weapon_busy = false;
    public static bool weapon_empty = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && !weapon_busy && !weapon_empty)
        {
            Remove_Bullet();
        }

        if(Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Reloading());
        }

        

    }


    private void Remove_Bullet()
    {
        for(int i = bullets.Length-1; i >= 0; i--)
        {
            if (bullets[i].activeInHierarchy)
            {
                bullets[i].SetActive(false);
                return;
            }
        }
        weapon_empty = true;
       
    }

    private IEnumerator  Reloading()
    {
        weapon_busy = true;
        for (int i = 0; i < bullets.Length; i++)
        {
            if(!bullets[i].activeInHierarchy) 
            {

                bullets[i].SetActive(true);
                yield return new WaitForSeconds(0.25f);

            }
            
        }
        weapon_busy = false;
        weapon_empty=false;
        
    }
    
}
