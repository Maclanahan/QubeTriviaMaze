using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class PathNode
    {
        protected double _f;
        protected double _g;
        protected double _h;
        protected int _x;
        protected int _y;
        protected PathNode _parentNode;

        public PathNode(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void assign(PathNode that)
        {
            _f = that.getF();
            _g = that.getG();
            _h = that.getH();
            _x = that.getX();
            _y = that.getY();
            _parentNode = that.getParentNode();
        }

        public double getF()
        {
            return _f;
        }

        public double getG()
        {
            return _g;
        }

        public double getH()
        {
            return _h;
        }

        public int getX()
        {
            return _x;
        }

        public int getY()
        {
            return _y;
        }

        public PathNode getParentNode()
        {
            return _parentNode;
        }

        public void setF(double newF)
        {
            _f = newF;
        }

        public void setG(double newG)
        {
            _g = newG;
        }

        public void setH(double newH)
        {
            _h = newH;
        }

        public void setParentNode(PathNode parent)
        {
            _parentNode = parent;
        }
    }
}
