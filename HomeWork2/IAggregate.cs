using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    /// <summary>
    /// Ref Link : 
    /// https://airbrake.io/blog/design-patterns/iterator-design-pattern
    /// </summary>

    interface IAggregate
    {
        IIterator CreateIterator();
    }

    interface IIterator
    {
        // Do you have the element in the next step?
        bool HasItem();
        //the next element brings
        Lesson NextItem();
        //the current element brings
        Lesson CurrentItem();
    }

    class LessonAggregate : IAggregate
    {
        List<Lesson> lessonList = new List<Lesson>();
        public void Add(Lesson Model) => lessonList.Add(Model);
        public Lesson GetItem(int index) => lessonList[index];
        public int Count { get => lessonList.Count; }
        public IIterator CreateIterator() => new LessonIterator(this);
    }

    class LessonIterator : IIterator
    {
        LessonAggregate aggregate;
        int currentindex;
        public LessonIterator(LessonAggregate aggregate) => this.aggregate = aggregate;
        public Lesson CurrentItem() => aggregate.GetItem(currentindex);
        public bool HasItem()
        {
            if (currentindex < aggregate.Count)
                return true;
            return false;
        }
        public Lesson NextItem()
        {
            if (HasItem())
                return aggregate.GetItem(currentindex++);

            return null;
        }
    }
}
