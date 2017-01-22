using UnityEngine;
using System.Collections;

public class DestroyOutMap : MonoBehaviour {


    void Start()
    {
        InvokeRepeating("DestroyOutMapRoutine", 5.0f, 5.0f);
    }

    private void DestroyOutMapRoutine()
    {
        float xPos = this.transform.position.x;
        float yPos = this.transform.position.y;

        if (xPos < -10.0f || xPos > 25.0f || yPos < -10.0f || yPos > 20.0f)
            Destroy(this.gameObject);
    }
}
