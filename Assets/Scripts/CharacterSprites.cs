using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CharacterSprites : MonoBehaviour
{
    [System.Serializable] // map of textures for facial expressions
    public class Expression
    {
        public string name;
        public SpriteRenderer sprite;
    }

    [SerializeField] List<Expression> expressions = new List<Expression>();

    private bool isForward;

    // Start is called before the first frame update
    void Start()
    {
        if (expressions.Count < 1)
        {
            Debug.LogError($"Character {name} has no available sprites.");
            return;
        }
        Debug.Log($"Character {name} created.");
        SetSprite(expressions[0].sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("Expression")]
    public void SetExpression(string expressionName)
    {
        // find the expression with the same name as we are looking for
        Expression expressionToUse = FindExpressionWithName(expressionName);
        if (expressionToUse == null)
        {
            Debug.LogError($"Character {name} has no Expression named {expressionName}.");
            return;
        }
        SetSprite(expressionToUse.sprite);
    }

    private Expression FindExpressionWithName(string expressionName)
    {
        var caseInsensitiveMode = System.StringComparison.InvariantCultureIgnoreCase;
        foreach (Expression expression in expressions)
        {
            if (expression.name.Equals(expressionName, caseInsensitiveMode))
            {
                return expression;
            }
        }
        return null;
    }

    [YarnCommand("Flip")]
    private void Flip()
    {
        if(isForward)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            isForward = false;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            isForward = true;
        }
    }

    private void SetSprite(SpriteRenderer sprite)
    {
        foreach(var test in expressions)
        {
            test.sprite.gameObject.SetActive(false);
        }

        sprite.gameObject.SetActive(true);
    }
}
