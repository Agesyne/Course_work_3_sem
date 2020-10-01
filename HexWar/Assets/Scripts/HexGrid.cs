using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;

	HexCell[] cells;

	public Text cellLabelPrefab;

	Canvas gridCanvas;

	HexMesh hexMesh;

	void Start()
	{
		hexMesh.Triangulate(cells);
	}

	void Awake()
	{
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[height * width];

		for (int y = 0, i = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				CreateCell(x, y, i++);
			}
		}
	}

	void CreateCell(int x, int y, int i)
	{
		Vector3 position;
		position.y = (y + x * 0.5f - x / 2) * (HexMetrics.innerRadius * 2f);
		position.z = 0f;
		position.x = x * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;

		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.y);
		label.text = x.ToString() + "\n" + y.ToString();
	}

	private void OnDrawGizmos()
	{
		if (cells == null)
		{
			return;
		}

		Gizmos.color = Color.black;
		for (int i = 0; i < cells.Length; i++)
		{
			Gizmos.DrawSphere(this.transform.position + cells[i].transform.localPosition, 1f);
		}
	}
}