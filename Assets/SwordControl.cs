using UnityEngine;
using System.Collections;

public class SwordControl : MonoBehaviour {
    
    private Animation anim;

    private bool space = false;

    private void Start () { anim = GetComponent<Animation>(); }

    private void FixedUpdate () {
        if (Input.GetAxis("Jump") > 0 && !space && !anim.isPlaying) {
            anim.Play("swing"); /// swing
            space = true;
        } else if (Input.GetAxis("Jump") == 0) space = false;
    }

    public bool isSwinging () { return anim.isPlaying; }


    /// OLD CODE


    //private GameObject lastHit;

    //public void doneSwinging () { character.GetComponent<CharacterControl>().doneSwinging(); lastHit = null; }

    //void OnTriggerEnter2D (Collider2D other)
    //{
    //    if (other.GetComponent<Enemy>() != null && character.GetComponent<CharacterControl>().swung && other.gameObject != lastHit)
    //    {
    //        other.GetComponent<Enemy>().damage(5);
    //        //character.GetComponent<CharacterControl>().heal(5);
    //        lastHit = other.gameObject;
    //    }
    //}
}
