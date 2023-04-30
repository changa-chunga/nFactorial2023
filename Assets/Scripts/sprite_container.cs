using UnityEngine;

public class sprite_container : MonoBehaviour
{
    public Character[] Objects;
    public static sprite_container instance;
    public sprite_container()
    {
        instance = this;
    }
    public AnimationSet request(string name, string AnimationIndex)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            if (Objects[i].index != name) continue;
            
            for (int k = 0; k < Objects[i].animations.Length; k++)
            {
                if (Objects[i].animations[k].animName == AnimationIndex)
                {
                    return Objects[i].animations[k];
                }
            }
            break;
        }

        return new AnimationSet();
    }

    public Sprite GetDefaultSprite(string name)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            if (Objects[i].index == name)
            {
                return Objects[i].defaultSprite;
                break;
            }
        }
        return null;
    }
}
[System.Serializable]
public struct Character
{
    public string index;
    public Sprite defaultSprite;
    public AnimationSet[] animations;
}