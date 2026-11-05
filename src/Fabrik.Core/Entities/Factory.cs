public class Factory
{
    public Storage Storage { get; private set; }

    public Factory(Storage storage)
    {
        Storage = storage;
    }
    public void CreatePackage()
    {
        if (Storage.IsFull)
        {
            return;
        }
        Storage.ReceivePackage();
    }
}
public class Storage
{
    public int PackagesToHandOut { get; private set; }
    public int StorageCapacity { get; private set; } = 100;
    public bool IsFull => PackagesToHandOut >= StorageCapacity;

    public void ReceivePackage()
    {
        if (IsFull)
        {
            throw new InvalidOperationException("Lagret är fullt!");
        }
        PackagesToHandOut += 1;
        return;
    }
    public void HandoutPackage()
    {
        if (PackagesToHandOut > 0)
        {
            PackagesToHandOut -= 1;
            return;
        }
        throw new InvalidOperationException("Lagret har inga paket att lämna ut!");
    }
}
public class Truck
{

    public int PackagesToDeliver { get; private set; } = 0;
    public int CurrentPlacement { get; private set; } = 0;
    public int LoadCapacity { get; private set; } = 20;
    public int StartPosition { get; private set; } = 0;
    public int DeliveryPlacement { get; private set; } = 5;

    public void MoveTruckForward()
    {
        if (CurrentPlacement >= DeliveryPlacement)
        {
            throw new InvalidOperationException("Lastbilen är redan framme!");
        }
        CurrentPlacement += 1;
        return;
    }
    public void MoveTruckBack()
    {
        if (CurrentPlacement <= StartPosition)
        {
            throw new InvalidOperationException("Lastbilen är redan tillbaka!");
        }
        CurrentPlacement -= 1;
        return;
    }

    public void PickupPackage(Storage storage)
    {
        if (CurrentPlacement != 0)
        {
            throw new InvalidOperationException("Lastbilen är inte redo att ta emot paket");
        }
        if (PackagesToDeliver >= LoadCapacity)
        {
            throw new InvalidOperationException("Lastbilen är full");
        }
        storage.HandoutPackage();
        PackagesToDeliver += 1;
        return;
    }
    public void DeliverPackages()
    {
        if (CurrentPlacement < DeliveryPlacement)
        {
            throw new InvalidOperationException("Lastbilen har inte kommit fram!");
        }
        if (PackagesToDeliver <= 0)
        {
            throw new InvalidOperationException("Lastbilen har inga paket!");
        }
        PackagesToDeliver = 0;
        return;
    }
}
public class HandleTick
{
    Storage storage = new();
    Factory baseFactory;
    Truck truck = new();

    public HandleTick()
    {
        baseFactory = new(storage);
    }
    public void Tick()
    {
        baseFactory.CreatePackage();

        bool atStart = truck.CurrentPlacement == truck.StartPosition;
        bool atEnd = truck.CurrentPlacement == truck.DeliveryPlacement;
        bool loaded = truck.PackagesToDeliver > 0;

        if (atStart && !loaded)
        {
            truck.PickupPackage(storage);
        }
        else if (loaded && !atEnd)
        {
            truck.MoveTruckForward();
        }
        else if (loaded && atEnd)
        {
            truck.DeliverPackages();
        }
        else if (!loaded && !atStart)
        {
            truck.MoveTruckBack();
        }
    }
}