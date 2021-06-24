using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatFormer
{
    class PlatformTreeGenerator
    {
    }

    public class PlatformData
    {
        public List<double> PlatformDataKeeper()
        {
            List<double> datalist = new List<double>();

            double positionX = 1;
            double positionY = 1;
            double lenght = 1;
            double height = 1;

            datalist.Add(positionX);
            datalist.Add(positionY);
            datalist.Add(lenght);
            datalist.Add(height);

            return datalist;
        }
        public List<double> PlatformDataGenerator()
        {
            List<double> generatedList = new List<double>();


            return generatedList;
        }
    }

    public class PlatformList
    {
        PlatformData data = new PlatformData();
        private Node firstPlatform;
        public bool IsEmpty()
        {
            return (firstPlatform == null);
        }

        public void InsertPlatformNode()
        {
            Node newNode = new Node();
            newNode.platform = new Platform(data.PlatformDataKeeper().IndexOf(0), data.PlatformDataKeeper().IndexOf(1), data.PlatformDataKeeper().IndexOf(2), data.PlatformDataKeeper().IndexOf(3));
            newNode.Right = firstPlatform;
            firstPlatform = newNode;
        }
        public Node DeleteFirstPlatform()
        {
            Node temp = firstPlatform;
            firstPlatform = firstPlatform.Right;
            return temp;
        }
        

        public void Test()
        {
            
        }
    }

    public class Node
    {
        public Platform platform;
        public Node Right;
        public Node Left;

        public void GeneratePlatform()
        {

        }
    }
}
