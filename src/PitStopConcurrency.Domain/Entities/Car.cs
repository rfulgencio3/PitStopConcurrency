using PitStopConcurrency.Domain.ValueObjects;

namespace PitStopConcurrency.Domain.Entities;

public class Car
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public TireWear TireWear { get; private set; }
    public FuelLevel FuelLevel { get; private set; }
    public bool IsInPit { get; private set; }
    public int CurrentLap { get; private set; }

    // Exemplo: informações adicionais relevantes
    public int TotalLaps { get; private set; }

    // Construtor para criação
    public Car(Guid id, string name, int totalLaps)
    {
        Id = id;
        Name = name;
        TotalLaps = totalLaps;
        TireWear = TireWear.Initial();    // Cria valor inicial de desgaste
        FuelLevel = FuelLevel.Full();     // Combustível cheio no início
        CurrentLap = 0;
        IsInPit = false;
    }

    // Métodos de domínio
    public void CompleteLap()
    {
        if (IsInPit) return;

        CurrentLap++;
        // Ao completar uma volta, podemos aumentar desgaste, diminuir combustível etc.
        TireWear = TireWear.IncreaseWear(5);
        FuelLevel = FuelLevel.Consume(5);
    }

    public void EnterPit()
    {
        IsInPit = true;
    }

    public void ExitPit()
    {
        IsInPit = false;
    }

    public void ChangeTires()
    {
        // Reseta o desgaste dos pneus
        TireWear = TireWear.Reset();
    }

    public void Refuel(int amount)
    {
        FuelLevel = FuelLevel.Add(amount);
    }
}
