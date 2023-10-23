using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBat : MonoBehaviour
{
  Rigidbody2D rb;

  [SerializeField]GameObject[] Spawn_Locations;

  [SerializeField] GameObject Bat;

  bool onTarget = false;

    [SerializeField] Animator bat_movement;
    


    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && onTarget && !MagazineController.weapon_busy && !MagazineController.weapon_empty)
        {
            rb.velocity = Vector2.zero;
            StartCoroutine("KillBat");
             
        }
    }
  

   
    private void OnTriggerEnter2D(Collider2D collision)
    { 
            onTarget = true;
        Debug.Log("On Target (SpawnBat.cs)");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            onTarget = false;
        Debug.Log("Off Target (SpawnBat.cs)");
    }



     public IEnumerator KillBat()
    {
        
        bat_movement.SetTrigger("Killed");
        float waiting_time = 0.7f;
        yield return new WaitForSeconds(waiting_time);
        Spawn_Bat();
        Debug.Log("NewObject Arrived (SpawnBat.cs)");
        Score.current_score += 5;
        Destroy(gameObject);
        

    }

    public void KillBat_API()
    {
        Spawn_Bat();
        Debug.Log("NewObject Arrived (SpawnBat.cs)");
        Destroy(gameObject);
        Score.bat_flew=true;
    }
    public void Spawn_Bat()
    {
        
        int i = Random.Range(0, Spawn_Locations.Length);

        Instantiate(Bat, Spawn_Locations[i].transform.position, Quaternion.identity);
        

    }

   

    


}
