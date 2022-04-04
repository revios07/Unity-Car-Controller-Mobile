using UnityEngine;

public class CarAnimations : MainCar
{
    protected void ChangeMaterial(int indexOfMaterial)
    {
        myMesh.material = materialsClass.materials[indexOfMaterial];
    }

    protected void ChangeTrailRenderersMaterial(int indexOfMaterial)
    {
        for (int i = 0; i < trailRenderers.Length; i++)
        {
            trailRenderers[i].material = materialsClass.materialsStraight[indexOfMaterial];
        }
    }
}
