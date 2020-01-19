using System;
using System.Collections.Generic;
using System.Text;

namespace Heap
{
    public class Heap
    {
        public int[] items = new int[10];
        public int size;

        public int Remove()
        {
            if (size == 0)
                return -1;

            var root = items[0];
            items[0] = items[--size];
            BubbleDown();

            return root;


        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= size && !IsValideParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Sawp(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index) > RightChild(index)) ?
                    LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }

        private bool IsValideParent(int index)
        {
            if (!HasRightChild(index))
                return true;

            var isValide = items[index] >= LeftChild(index);

            if (!HasRightChild(index))
                isValide &= items[index] >= RightChild(index);

            return isValide;
        }

        private int RightChild(int index)
        {
            return items[RightChildIndex(index)];
        }

        private int LeftChild(int index)
        {
            return items[LeftChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        public void Insert(int value)
        {
            if (IsFull())
                return;

            items[size++] = value;

            BubbleUp();
        }

        public bool IsFull()
        {
            return size == items.Length;
        }


        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index] > items[GetParentIndex(index)])
            {
                Sawp(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void Sawp(int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }
    }
}



