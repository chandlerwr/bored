using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour {

    public GameObject swordParent; /// reference to sword parent object for rotation
    public SwordControl swordControl; /// reference to sword control script to check if swinging

    public float maxSpeed = 10f; /// the max speed of the character

    private int swordAng = 0; /// angle of sword pos in deg
	
	private void FixedUpdate () {
        /// MOVEMENT
        float 
            h = Input.GetAxis("Horizontal"),
            v = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed * h, maxSpeed * v);

        /// SWORD POSITIONING
        if (!swordControl.isSwinging() && ( h != 0 || v != 0 )) {
            swordAng = retSwordPos(h, v);
            swordParent.transform.localPosition = new Vector3(
                .1f * Mathf.Cos(Mathf.Rad2Deg * swordAng),
                .1f * Mathf.Sin(Mathf.Rad2Deg * swordAng),
                swordParent.transform.localPosition.z);
            swordParent.transform.localRotation = Quaternion.Euler(
                swordParent.transform.localRotation.eulerAngles.x,
                swordParent.transform.localRotation.eulerAngles.y,
                swordAng);
        }
    }

    /// <summary>
    /// Function to calculate sword position based off of horizontal and vertical axis data.
    /// </summary>
    /// <param name="h">Horizontal axis</param>
    /// <param name="v">Vertical axis</param>
    /// <returns>Angle in degrees for sword.</returns>
    private int retSwordPos (float h, float v) {
        int x = 0;
        if (h > 0) x = 1;
        if (h < 0) x = -1;
        int y = 0;
        if (v > 0) y = 1;
        if (v < 0) y = -1;
        int ang = Mathf.RoundToInt(Mathf.Rad2Deg * Mathf.Atan2(y, x));
        if (ang < 0) ang += 360;
        return ang;
    }


    /// Old code


    //public bool 
    //    haveSword = false,
    //    swung = false;

    //private bool spaceUpped = true;
    //private int Health = 100;

    //public GameObject healthbar;
    //public GameObject health;


    /// IN FIXED_UPDATE

    //if (haveSword && Input.GetAxis("Jump") > 0 && !swung && spaceUpped)
    //{
    //    sword.GetComponent<Animator>().SetTrigger("swing");
    //    swung = true;
    //    spaceUpped = false;
    //} else if (Input.GetAxis("Jump") == 0) { spaceUpped = true; }

    //if (Health == 100) { healthbar.SetActive(false); }
    //else if (!healthbar.activeInHierarchy) { healthbar.SetActive(true); }

    //health.transform.localScale = new Vector3(((float)Health)/10, health.transform.localScale.y, health.transform.localScale.z);

    //sword.GetComponent<Animator>().SetBool("holding", haveSword);
    /// END FIXED_UPDATE


    //void OnCollisionEnter2D (Collision2D other)
    //{
    //    if (other.gameObject == sword && !haveSword)
    //    {
    //        haveSword = true;
    //        other.collider.isTrigger = true;
    //        other.transform.parent = GetComponent<Transform>();
    //        other.transform.localPosition = new Vector3(.2f, -.11f, -1);
    //        other.gameObject.GetComponent<Animator>().SetBool("holding", true);
    //        //other.transform.eulerAngles = new Vector3(0, 0, -18.27f);
    //        //sword.GetComponent<Animator>().applyRootMotion = false;
    //        sword.GetComponent<Animator>().rootPosition = new Vector3(.2f, -.11f, -1);
    //    }
    //}

    //public void damage (int points) { Health -= points; if (Health <= 0) { SceneManager.LoadScene(SceneNames.DEATH); } }

    //public void heal (int points) { Health += points; if (Health > 100) { Health = 100; } /*Debug.Log("Heal");*/ }
}
