using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class Pathfinder
    {
        protected PathNode[,] _nodes;
        protected Door[,] _hDoors;
        protected Door[,] _vDoors;

        public Pathfinder(PathNode[,] nodes, Door[,] hDoors, Door[,] vDoors)
        {
            _nodes = nodes;
            _hDoors = hDoors;
            _vDoors = vDoors;
        }

        public List<PathNode> findPath(PathNode firstNode, PathNode destNode)
        {
            List<PathNode> openNodes = new List<PathNode>();
            List<PathNode> closedNodes = new List<PathNode>();
            PathNode currentNode = firstNode;
            PathNode testNode;
            List<PathNode> connectedNodes;
            double travelCost = 1.0;
            double g;
            double h;
            double f;
            currentNode.setG(0);
            currentNode.setH(Pathfinder.manhattanHeuristic(currentNode, destNode, travelCost));
            currentNode.setF(currentNode.getG() + currentNode.getH());
            int dim = _nodes.Length;
            int len = 0;
            for (int i = 0; i < dim; i++)
            {
                len += _nodes.GetLength(i);
            }
            int j = 0;

            while (currentNode != destNode)
            {
                connectedNodes = this.findConnectedNodes(currentNode);
                len = connectedNodes.Count;
                for (j = 0; j < len; ++j)
                {
                    testNode = connectedNodes[j];
                    if (testNode == currentNode || checkTraversable(currentNode, testNode))
                    {
                        continue;
                    }
                    g = currentNode.getG() + travelCost;
                    h = manhattanHeuristic(testNode, destNode, travelCost);
                    f = g + h;
                    //if ( Pathfinder.isOpen(testNode, openNodes) || Pathfinder.isClosed( testNode, closedNodes) )	
                    if (openNodes.Contains<PathNode>(testNode) || closedNodes.Contains<PathNode>(testNode))
                    {
                        if (testNode.getF() > f)
                        {

                            testNode.setF(f);
                            testNode.setG(g);
                            testNode.setH(h);
                            testNode.setParentNode(currentNode);
                        }
                    }
                    else
                    {
                        testNode.setF(f);
                        testNode.setG(g);
                        testNode.setH(h);
                        testNode.setParentNode(currentNode);
                        openNodes.Add(testNode);
                    }
                }
                closedNodes.Add(currentNode);
                if (openNodes.Count == 0)
                {
                    return null;//basically the only line we need to check on when we get the list back
                }
                openNodes = sortByF(openNodes);

                currentNode = openNodes.ElementAt(0);
                openNodes.RemoveAt(0);
            }
            return Pathfinder.buildPath(destNode, firstNode);

        }

        private static List<PathNode> buildPath(PathNode destinationNode, PathNode startNode)
        {
            List<PathNode> path = new List<PathNode>();
            PathNode node = destinationNode;
            path.Add(node);
            while (node != startNode)
            {
                node = node.getParentNode();
                path.Add(node);
            }
            return path;
        }

        private static double manhattanHeuristic(PathNode node, PathNode destinationNode, double cost = 1.0, double diagonalCost = 1.0)
        {
            double dx = Math.Abs(node.getX() - destinationNode.getX());
            double dy = Math.Abs(node.getY() - destinationNode.getY());
            return dx + dy;
        }

        public List<PathNode> findConnectedNodes(PathNode node)
        {
            List<PathNode> connectedNodes = new List<PathNode>();
            PathNode testNode;
            int dim = _nodes.Length;
            int len = 0;
            for (int i = 0; i < dim; i++)
            {
                len += _nodes.GetLength(i);
            }
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)//only because we have a square maze
                {
                    testNode = _nodes[i, j];

                    if (checkTraversable(node, testNode))
                    {
                        connectedNodes.Add(testNode);
                    }

                    /*if ((testNode.getX() == node.getX() - 1 ) && testNode.getY() == node.getY())
                    {
                        
                        if(i > 0)
                        {
                            if(_doors[i - 1,j].State != 2)//check if door that direction isn't locked
                            {
                                connectedNodes.Add(testNode);
                            }
                        }
                    }
                    else if ((testNode.getX() == node.getX() + 1) && testNode.getY() == node.getY())
                    {
                        if (i < dim)
                        {
                            if (_doors[i + 1, j].State != 2)
                            {
                                connectedNodes.Add(testNode);
                            }
                        }

                    }
                    else if ((testNode.getY() == node.getY() - 1) && testNode.getX() == node.getX())
                    {
                        if (j > 0)
                        {
                            if (_doors[i, j - 1].State != 2)
                            {
                                connectedNodes.Add(testNode);
                            }
                        }
                    }
                    else if ((testNode.getY() == node.getY() + 1) && testNode.getX() == node.getX())
                    {
                        if (j < dim)
                        {
                            if (_doors[i, j + 1].State != 2)
                            {
                                connectedNodes.Add(testNode);
                            }
                        }
                    }*/
                }

            }
            return connectedNodes;
        }

        public bool checkTraversable(PathNode curNode, PathNode testNode)
        {
            //1 check which direction door is in
            if (curNode.getX() == testNode.getX())
            {
                if (testNode.getY() == curNode.getY() - 1)
                {
                    if (_vDoors[curNode.getX(), curNode.getY() - 1].State != 2)//2 check if that door is open
                    {
                        return true;
                    }
                }
                else if (testNode.getY() == curNode.getY() + 1)
                {
                    if (_vDoors[curNode.getX(), curNode.getY() + 1].State != 2)
                    {
                        return true;
                    }
                }
            }
            else if (testNode.getY() == testNode.getY())
            {
                if (testNode.getX() == curNode.getX() - 1)
                {
                    if (_hDoors[curNode.getX() - 1, curNode.getX()].State != 2)
                    {
                        return true;
                    }
                }
                else if (testNode.getX() == curNode.getX() + 1)
                {
                    if (_hDoors[curNode.getX() + 1, curNode.getX()].State != 2)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        private List<PathNode> sortByF(List<PathNode> nodes)
        {
            bool sorted = false;
            PathNode temp = new PathNode(0, 0);
            while (!sorted)
            {
                sorted = true;
                for (int i = 1; i < nodes.Count; i++)
                {
                    if (nodes.ElementAt<PathNode>(i).getF() <= nodes.ElementAt<PathNode>(i - 1).getF())
                    {
                        temp.assign(nodes.ElementAt<PathNode>(i));
                        nodes.ElementAt<PathNode>(i).assign(nodes.ElementAt<PathNode>(i - 1));
                        sorted = false;
                    }
                }
            }
            return nodes;
        }
    }
}
