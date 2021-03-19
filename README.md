# Parallelized Codes in C#

- Many personal computers and workstations have multiple CPU cores that enable multiple threads to be executed simultaneously. 
- To take advantage of the hardware, you can parallelize your code to distribute work across multiple processors.
---
- In parallel computing, an embarrassingly parallel workload or problem is one where little or no effort is needed to separate the problem into a number of parallel tasks. This is often the case where there is little or no dependency or need for communication between those parallel tasks, or for results between them.
---
- The Task Parallel Library **(TPL)** is a set of public types and APIs in the System.Threading and System.Threading.Tasks namespaces. 
- The purpose of the TPL is to make developers more productive by simplifying the process of adding parallelism and concurrency to applications. 
- The TPL scales the degree of concurrency dynamically to most efficiently use all the processors that are available.
- In addition, the TPL handles the partitioning of the work, the scheduling of threads on the ThreadPool, cancellation support, state management, and other low-level details. 
- By using TPL, you can maximize the performance of your code while focusing on the work that your program is designed to accomplish.
---
- Multiple parallelized algorithms realized in C# including:
    - Monte Carlo PI Approximation
    - Parallel Numerical Integration
    - Parallel QuickSort
