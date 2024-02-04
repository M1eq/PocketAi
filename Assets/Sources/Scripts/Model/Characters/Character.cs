using UnityEngine;

public class Character : MonoBehaviour
{
    public Health Health => _health;

    private readonly Health _health = new Health();
}
