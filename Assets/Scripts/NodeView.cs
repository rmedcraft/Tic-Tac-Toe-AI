using UnityEngine;

public class NodeView : MonoBehaviour
{
    public GameObject tile;
    public void Init(Node node)
    {
        if (tile != null)
        {
            // gameObject refers to the NodeView gameObject
            // gameObject is kinda like saying this.something() in every other programming language
            gameObject.name = "Node (" + node.position.x + ", " + node.position.z + ")";
            Debug.Log("HERE!!!");
            gameObject.transform.position = node.position;
            Debug.Log(gameObject.transform.position.x + ", " + gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
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
