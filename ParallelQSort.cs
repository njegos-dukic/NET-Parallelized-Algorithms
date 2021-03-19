using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelator
{
    class ParallelQSort
    {
        static void Swap<T>(T[] array, int i, int j) where T : IComparable<T>
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static int Partition<T>(T[] array, int from, int to, int pivot) where T : IComparable<T>
        {
            // Pre: from <= pivot < to (other than that, pivot is arbitrary)
            var arrayPivot = array[pivot];  // pivot value
            Swap(array, pivot, to - 1); // move pivot value to end for now, after this pivot not used
            var newPivot = from; // new pivot 
            for (int i = from; i < to - 1; i++) // be careful to leave pivot value at the end
            {
                // Invariant: from <= newpivot <= i < to - 1 && 
                // forall from <= j <= newpivot, array[j] <= arrayPivot && forall newpivot < j <= i, array[j] > arrayPivot
                //if (array[i] <= arrayPivot)
                if (array[i].CompareTo(arrayPivot) != -1)
                {
                    Swap(array, newPivot, i);  // move value smaller than arrayPivot down to newpivot
                    newPivot++;
                }
            }
            Swap(array, newPivot, to - 1); // move pivot value to its final place
            return newPivot; // new pivot
            // Post: forall i <= newpivot, array[i] <= array[newpivot]  && forall i > ...
        }

        static void ParallelQuickSort<T>(T[] array, int from, int to, int depthRemaining) where T : IComparable<T>
        {
            int pivot = from + (to - from) / 2; // could be anything, use middle
            pivot = Partition<T>(array, from, to, pivot);
            if (depthRemaining > 0)
            {
                Parallel.Invoke(
                    () => ParallelQuickSort(array, from, pivot, depthRemaining - 1),
                    () => ParallelQuickSort(array, pivot + 1, to, depthRemaining - 1));
            }
            else
            {
                ParallelQuickSort(array, from, pivot, 0);
                ParallelQuickSort(array, pivot + 1, to, 0);
            }
        }
    }
}
