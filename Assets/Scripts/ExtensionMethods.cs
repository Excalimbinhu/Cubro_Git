using UnityEngine;

public static class ExtensionMethods
{
  public static Color _color01 = new Color(1f, 0.5f, 0f, 1f);
  public static Color _color02 = new Color(1f, 0.9f, 0.4f, 1f);
  public static GameObject _lastPath;

  public static bool ChangeColor(this Material playerMat, bool colored)
  {
    if (colored)
      playerMat.color = _color02;
    else
      playerMat.color = _color01;

    return !colored;
  }

  public static void SetColor(this Material pathMat, bool colored)
  {
    if (colored)
      pathMat.color = _color01;
    else
      pathMat.color = _color02;
  }

  public static Vector3 SetDirection(this PathList pathList, bool right)
  {
    if (right == false)
      return pathList._path.transform.position + (Vector3.forward * 2.5f);
    else
      return pathList._path.transform.position + (Vector3.left * 2.5f);
  }
}
