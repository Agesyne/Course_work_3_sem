using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
	public GridForm gridForm;
	public int width = 6;
	public int height = 6;

	public HexCell cellPrefab;
	public Text cellLabelPrefab;

	HexCell[] cells;

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

		if (gridForm == GridForm.Square)
        {
			cells = new HexCell[height * width];

			for (int y = 0, i = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					CreateCell(x, y, i++);
				}
			}
		}
		else
        {
			var min = Mathf.Min(height, width);
			// Arithmetic progression
			cells = new HexCell[(1 + 3 * (min - 1)) * min];

			var counter = 0;
            for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (Mathf.Abs(x) + Mathf.Abs(y) <= min)
					{
						CreateCell(x, y, counter);
						counter++;
					}
				}
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
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);

		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.y);
		label.text = cell.coordinates.ToStringOnSeparateLines();
	}

	#region OnDrawGizmos
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
    #endregion

 //   #region Mouse touch
 //   void Update()
	//{
	//	if (Input.GetMouseButton(0))
	//	{
	//		HandleInput();
	//	}
	//}

	//void HandleInput()
	//{
	//	Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
	//	RaycastHit hit;
	//	if (Physics.Raycast(inputRay, out hit))
	//	{
	//		TouchCell(hit.point);
	//	}
	//}

	//void TouchCell(Vector3 position)
	//{
	//	position = transform.InverseTransformPoint(position);
	//	Debug.Log("touched at " + position);
	//}
 //   #endregion
}