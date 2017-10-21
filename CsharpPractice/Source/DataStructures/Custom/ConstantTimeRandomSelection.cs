// We have a pool of machines that can be either be busy or free. Implement a data structure that supports following three
// operations with constant time complexity:
//
// 1. Mark machine with given ID as busy.
// 2. Mark machine with given ID as free.
// 3. Return ID of a random machine from pool of free machines.

using System;

namespace CsharpPractice.Source.DataStructures.Custom
{
    internal static class ConstantTimeRandomSelection
    {
        public static void Main(string[] args)
        {
            int machinePoolSize = 64;

            MachinePool machinePool = new MachinePool(machinePoolSize);

            Console.Write("Random free machine IDs while setting them busy: ");

            while (machinePool.FreeCount() > 0)
            {
                int freeMachineId = machinePool.GetRandomFree();
                Console.Write(freeMachineId + " ");
                machinePool.SetBusy(freeMachineId);
            }

            Console.WriteLine();

            Console.Write("Random free machine IDs while setting machines free in order: ");

            for (int machineId = 0; machineId < machinePoolSize; machineId++)
            {
                machinePool.SetFree(machineId);
                Console.Write(machinePool.GetRandomFree() + " ");
            }

            Console.WriteLine();
        }

        private sealed class MachinePool
        {
            private readonly int allMachineCount;
            private int freeMachineCount;

            private readonly int[] freeBusyMachineIds;
            private readonly int[] machinePositions;

            private readonly Random random = new Random();

            public MachinePool(int machinePoolSize)
            {
                this.allMachineCount = machinePoolSize;
                this.freeMachineCount = machinePoolSize;

                this.freeBusyMachineIds = new int[machinePoolSize];
                this.machinePositions = new int[machinePoolSize];

                for (int machinePosition = 0; machinePosition < this.allMachineCount; machinePosition++)
                {
                    int machineId = machinePosition;

                    this.freeBusyMachineIds[machinePosition] = machineId;
                    this.machinePositions[machineId] = machinePosition;
                }
            }

            public void SetBusy(int machineId)
            {
                if (machineId < 0 || machineId >= allMachineCount)
                {
                    throw new ArgumentException($"Machine ID: [{machineId}] is not valid.");
                }

                int machinePosition = this.machinePositions[machineId];
                if (machinePosition >= this.freeMachineCount)
                {
                    throw new InvalidOperationException($"Machine with ID: [{machineId}] is already busy.");
                }

                this.SwapMachines(machinePosition, --this.freeMachineCount);
            }

            public void SetFree(int machineId)
            {
                if (machineId < 0 || machineId >= allMachineCount)
                {
                    throw new ArgumentException($"Machine ID: [{machineId}] is not valid.");
                }

                int machinePosition = this.machinePositions[machineId];
                if (machinePosition < this.freeMachineCount)
                {
                    throw new InvalidOperationException($"Machine with ID: [{machineId}] is already free.");
                }

                this.SwapMachines(machinePosition, this.freeMachineCount++);
            }

            public int GetRandomFree()
            {
                return this.freeBusyMachineIds[random.Next(freeMachineCount)];
            }

            public int FreeCount()
            {
                return this.freeMachineCount;
            }

            private void SwapMachines(int machine1Position, int machine2Position)
            {
                int tempMachineId = this.freeBusyMachineIds[machine1Position];
                this.freeBusyMachineIds[machine1Position] = this.freeBusyMachineIds[machine2Position];
                this.freeBusyMachineIds[machine2Position] = tempMachineId;

                this.machinePositions[this.freeBusyMachineIds[machine1Position]] = machine1Position;
                this.machinePositions[this.freeBusyMachineIds[machine2Position]] = machine2Position;
            }
        }
    }
}
