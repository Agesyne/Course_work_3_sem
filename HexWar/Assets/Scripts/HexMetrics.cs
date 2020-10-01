using UnityEngine;

public static class HexMetrics
{
	public const float outerRadius = 10f;

	public const float innerRadius = outerRadius * 0.866025404f;

    /// <summary>
    /// Top orientation
    /// </summary>
    //public static Vector3[] corners = {
    //    new Vector3(0f, outerRadius, 0f),
    //    new Vector3(innerRadius, 0.5f * outerRadius, 0f),
    //    new Vector3(innerRadius, -0.5f * outerRadius, 0f),
    //    new Vector3(0f,-outerRadius, 0f),
    //    new Vector3(-innerRadius, -0.5f * outerRadius, 0f),
    //    new Vector3(-innerRadius, 0.5f * outerRadius, 0f),
    //    new Vector3(0f, outerRadius, 0f)
    //};

    /// <summary>
    /// Left orientation
    /// </summary>
    public static Vector3[] corners =
    {
        new Vector3(-outerRadius, 0f, 0f),
        new Vector3(-0.5f * outerRadius, innerRadius, 0f),
        new Vector3(0.5f * outerRadius, innerRadius, 0f),
        new Vector3(outerRadius, 0f, 0f),
        new Vector3(0.5f * outerRadius, -innerRadius, 0f),
        new Vector3(-0.5f * outerRadius, -innerRadius, 0f),
        new Vector3(-outerRadius, 0f, 0f)
    };
}