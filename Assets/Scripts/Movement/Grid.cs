using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
	public class Grid 
	{
	
		private Vector2 gridWorldSize;
		private float nodeRadius;
		private Node[,] _grid;
		private int _gridSizeX = 40, _gridSizeY = 40;
		private float _hexWidth = 1;
		private float _hexHeight = 1;
		public List<Node> Path;
	
		public Grid()
		{
			CreateGrid();
		}

		private void CreateGrid()
		{
			_grid = new Node[_gridSizeX, _gridSizeY];
			for (int x = 0; x < _gridSizeX; x++)
			{
				for (int y = 0; y < _gridSizeY; y++)
				{
					Vector3 worldPoint = new Vector3( x * _hexWidth,y * _hexHeight, 0);
					bool walkable = true;
					_grid[x, y] = new Node(walkable, worldPoint, x, y);
				}
			}
		}

		public List<Node> GetNeighbours(Node node)
		{
			List<Node> neighbours = new List<Node>();

			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (x == 0 && y == 0)
						continue;

					int checkX = node.Get_GridX() + x;
					int checkY = node.Get_GridY() + y;

					if (checkX >= 0 && checkX < _gridSizeX && checkY >= 0 && checkY < _gridSizeY)
					{
						neighbours.Add(_grid[checkX, checkY]);
					}
				}
			}

			return neighbours;
		}

		public Node NodeFromWorldPoint(Vector3 worldPosition)
		{
			return _grid[Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y)];
		}
	}
}
