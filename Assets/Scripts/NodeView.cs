using UnityEngine;

public class NodeView : MonoBehaviour {
    public GameObject tile;
    public float borderSize = 0.01f;
    TicTacToeGame game;

    TextMesh text;
    Node node;
    // public ViewType viewType = ViewType.closed;
    public void Init(Node node, TicTacToeGame game) {
        if (tile != null) {
            this.node = node;
            this.game = game;
            // gameObject refers to the NodeView gameObject
            // gameObject is kinda like saying this.something() in every other programming language
            tile.name = "Node (" + node.position.x + ", " + node.position.z + ")";
            tile.transform.position = node.position;
            tile.transform.localScale = new Vector3(1f - borderSize, 1f, 1f - borderSize);

            // Adds a hitbox to each tile, necessary for click detection
            tile.AddComponent<BoxCollider>();

            // all for adding text to the nodeview
            GameObject t = new GameObject();
            text = t.AddComponent<TextMesh>();
            text.text = "";
            text.fontSize = 40;
            text.characterSize = 0.2f;

            text.transform.position = node.position;

            text.transform.eulerAngles = new Vector3(90, 0, 0);
            text.anchor = TextAnchor.MiddleCenter;

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
                    game.OnCellClicked(node.xIndex, node.yIndex);
                }
            }
        }
    }
    public void DrawText(string s) {
        text.text = s;
    }
}