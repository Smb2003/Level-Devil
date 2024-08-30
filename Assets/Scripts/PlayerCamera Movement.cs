using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance; // agye ka distance( hmne 2 dya hai khudse phr wo khud set krlega)..
    [SerializeField] private float cameraSpeed;   // ktni dor camera hoga (0.5 rkha hai same uper wali line)..
    private float lookAhead;  // agye dekho

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        // yhn player ki position x ko change kra hai kioke camera horizontally move hoga. Y and Z ki zaroorat nhi hai.
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        // yhn hmne math ka function LERP istemal kra hai jo ky values ko change krta hai linearly 2 values lekr, time (t) lekr..
        // (aheadDistance * player.localScale.x) -> iska mtlb ye hai ky agye ka distance either left side ka ya right side ka konsa hoga tbhi hmne muitply kra hai ussy (transform.localScale.x) sy bcz value 1 ayi issy tu mtlb right side hai and if -1 tu mtlb left side...

    }
}
