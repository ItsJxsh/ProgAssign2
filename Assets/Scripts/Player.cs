using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public int Health = 3;
    public int score = 0;
    public float speed = 4.0f;
    Rigidbody2D rb;
    public GameObject bombPrefab;
    public float explosionTime = 2.5f;
    public int bombCount = 1;
    private int bombsRemaining;

    public Explosion explosionPrefab;
    public float explosionLength = 2.0f;
    public int explosionRadius = 1;
    public LayerMask explosionLayerMask;

    public Tilemap destroyableTiles;
    public Tilemap itemTiles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bombsRemaining = bombCount;
    }


    // Challenge: Rotate the player with E and Q, then move the player in that direction!
    void Update()
    {
        float dt = Time.deltaTime;
        float xDir = 0.0f;
        float yDir = 0.0f;

        if (Health == 0)
        {
            Debug.Log("Game Over");
            Debug.Log("Score:" + score);
            Debug.Break();
        }

        if (Input.GetKeyDown(KeyCode.Space) && bombsRemaining > 0)
        {
            StartCoroutine(PlaceBomb());
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            yDir = 1.0f;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            yDir = -1.0f;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            xDir = -1.0f;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            xDir = 1.0f;
        }
        else
        {
            gameObject.GetComponent<AnimationScript>().idle = true;
        }


        Vector2 direction = new Vector2(xDir, yDir).normalized;
        rb.velocity = direction * speed;
    }


    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(explosionTime);

        position = bomb.transform.position;

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.Start);
        explosion.DestroyAfter(explosionTime);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);




        Destroy(bomb);
        bombsRemaining++;
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0)
        {
            return;
        }

        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            ClearDestroyable(position);
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.Middle : explosion.End);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionTime);


        Explode(position, direction, length - 1);
    }

    private void ClearDestroyable(Vector2 position)
    {
        Vector3Int cell = destroyableTiles.WorldToCell(position);
        TileBase tile = destroyableTiles.GetTile(cell);

        if (tile != null)
        {
            destroyableTiles.SetTile(cell, null);
            score += 100;
        }
    }

    public void AddBomb()
    {
        bombCount++;
        bombsRemaining++;
    }
    public void AddRadius()
    {
        explosionRadius++;
    }
    public void AddSpeed()
    {
       speed *= 2;
    }
}