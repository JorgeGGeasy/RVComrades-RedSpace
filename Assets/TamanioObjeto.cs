using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class TamanioObjeto : MonoBehaviour
    {
        [SerializeField]
        LinearMapping linearMapping;
    // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (linearMapping.value < 0.4)
            {
                gameObject.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
            }
            else if (linearMapping.value > 0.4 && linearMapping.value < 0.8)
            {
                gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            else if (linearMapping.value > 0.8)
            {
                gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
    }
}
