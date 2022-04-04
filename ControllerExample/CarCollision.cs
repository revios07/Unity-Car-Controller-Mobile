using UnityEngine;

public class CarCollision : CarAnimations
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Puan")
        {
            int index = other.gameObject.GetComponent<Collectable>().index;
            //Cars Material Change
            ChangeMaterial(index);

            //Trail Renderer Materials Change
            ChangeTrailRenderersMaterial(index);

            other.gameObject.SetActive(false);
        }
    }
}
