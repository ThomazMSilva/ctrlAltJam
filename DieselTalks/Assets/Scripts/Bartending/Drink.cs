using UnityEngine;

public class Drink : MonoBehaviour
{
    public class Flavour
    {
        public float
            sourness,
            bitterness,
            sweetness,
            saltiness;
    }

    [SerializeField]
    private Flavour[] correctFlavour = new Flavour[3];

    void CompareFlavours(float sourness, float bitterness, float sweetness, float saltiness)
    {

    }
}



