using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //orders waypoints in scene so enemy movement script follows correct order
    public static Transform[] waypointList;
    void Awake()
    {
        waypointList = new Transform[transform.childCount];
        for (int i = 0; i < waypointList.Length; i++)
        {
            waypointList[i] = transform.GetChild(i);
        }
    }
}
