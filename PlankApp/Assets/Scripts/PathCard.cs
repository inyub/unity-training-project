using UnityEngine;

[CreateAssetMenu(fileName = "PathCard", menuName = "Project/PathCard", order = 1)]
public class PathCard : ScriptableObject
{
    public new string name; //Beginner 1
    public string length; //2 Weeks
    public string goal; // 2 Min Planks

    public int steps; // 5 Workouts

    public Sprite icon;
}
