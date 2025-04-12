using UnityEngine;

public class NodeView : MonoBehaviour {
    public GameObject tile;
    public float borderSize = 0.01f;

    Node node;
    public ViewType viewType = ViewType.closed;
    public void Init(Node node) {
        if (tile != null) {
            this.node = node;
            // gameObject refers to the NodeView gameObject
            // gameObject is kinda like saying this.something() in every other programming language
            tile.name = "Node (" + node.position.x + ", " + node.position.z + ")";
            tile.transform.position = node.position;
            tile.transform.localScale = new Vector3(1f - borderSize, 1f, 1f - borderSize);
        } else {
            Debug.LogWarning("Tile does not exist!");
        }
    }

    void ColorNode(Color color, GameObject gameObject) {
        if (gameObject != null) {
            Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();
            gameObjectRenderer.material.color = color;
        }
    }

    public void ColorNode(Color color) {
        ColorNode(color, tile);
    }

    void Update() {
        // handles click detection for each individual node with a raycaster
        // cant use the OnMouseDown method because we are using tile as the nodeview object.
        // you can only change a node state manually if the game is paused
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // out hit means to store the output in the hit object
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.gameObject == tile) {
                    viewType = ViewType.open;
                }
            }
        }
    }
}

public enum ViewType {
    open = 0,
    closed = 1,
}