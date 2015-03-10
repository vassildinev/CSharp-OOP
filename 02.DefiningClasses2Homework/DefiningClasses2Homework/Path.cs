namespace DefiningClasses2Homework
{
    using System.Collections;
    using System.Collections.Generic;
    class Path:IEnumerable
    {

        // field
        private List<Point3D> path;

        // constructors
        public Path()
        {
            this.path = new List<Point3D>();
        }
        public Path(uint pathLength)
        {
            this.path = new List<Point3D>((int)pathLength);
        }

        // properties
        public int Length
        {
            get
            {
                return this.path.Count;
            }
        }

        //indexation
        public Point3D this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new System.IndexOutOfRangeException();
                }

                return this.path[index];
            }
            set
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new System.IndexOutOfRangeException();
                }

                this.path[index] = value;
            }
        }

        // methods
        public void Add(Point3D point)
        {
            this.path.Add(point);
        }

        public void Pop()
        {
            this.path.RemoveAt(this.path.Count - 1);
        }

        // implementing the IEnumerable interface
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                yield return this[i];
            }
        }
    }
}
