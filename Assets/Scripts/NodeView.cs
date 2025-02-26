using UnityEngine;

public class NodeView : MonoBehaviour
{
    public GameObject tile;
    public float borderSize = 0.15f;
    public void Init(Node node)
    {
        if (tile != null)
        {
            // gameObject refers to the NodeView gameObject
            // gameObject is kinda like saying this.something() in every other programming language
            gameObject.name = "Node (" + node.position.x + ", " + node.position.z + ")";
            gameObject.transform.position = node.position;
            gameObject.transform.localScale = new Vector3(1f - borderSize, 1f, 1f - borderSize);
        }
        else
        {
            Debug.LogWarning("Tile does not exist!");
        }
    }

    void ColorNode(Color color, GameObject gameObject)
    {
        if (gameObject != null)
        {
            Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();
            gameObjectRenderer.sharedMaterial.color = color;
        }
    }

    public void ColorNode(Color color)
    {
        ColorNode(color, tile);
    }
}
