namespace Infestation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class HoldingExtendedPen : HoldingPen
    {
        private List<Unit> containedUnits = new List<Unit>();

        protected override void DispatchCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "insert":
                    this.ExecuteInsertUnitCommand(commandWords);
                    break;
                case "proceed":
                    this.ExecuteProceedSingleIterationCommand();
                    break;
                case "supplement":
                    this.ExecuteAddSupplementCommand(commandWords);
                    break;
                case "status":
                    this.ExecutePrintStatusCommand();
                    break;
                default:
                    break;
            }
        }

        private void ExecutePrintStatusCommand()
        {
            foreach (var unit in this.containedUnits)
            {
                Console.WriteLine(unit);
            }
        }

        protected override void ExecuteProceedSingleIterationCommand()
        {
            var containedUnitsInfo = this.containedUnits.Select((unit) => unit.Info);

            IEnumerable<Interaction> requestedInteractions =
                from unit in this.containedUnits
                select unit.DecideInteraction(containedUnitsInfo);

            requestedInteractions = requestedInteractions.Where((interaction) => interaction != Interaction.PassiveInteraction);

            foreach (var interaction in requestedInteractions)
            {
                this.ProcessSingleInteraction(interaction);
            }

            this.containedUnits.RemoveAll((unit) => unit.IsDestroyed);
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            string supplementType = commandWords[1];
            string targetUnitId = commandWords[2];
            IEnumerable<Unit> units;

            switch (supplementType)
            {
                case "PowerCatalyst":
                    units = containedUnits.Where(u => u.Id == targetUnitId);
                    foreach (var unit in units)
                    {
                        unit.AddSupplement(new PowerCatalyst());
                    }
                    break;
                case "HealthCatalyst":
                    units = containedUnits.Where(u => u.Id == targetUnitId);
                    foreach (var unit in units)
                    {
                        unit.AddSupplement(new HealthCatalyst());
                    }
                    break;
                case "AggressionCatalyst":
                    units = containedUnits.Where(unit => unit.Id == targetUnitId);
                    foreach (var unit in units)
                    {
                        unit.AddSupplement(new AggressionCatalyst());
                    }
                    break;
                case "Weapon":
                    units = containedUnits.Where(unit => unit.Id == targetUnitId);
                    foreach (var unit in units)
                    {
                        unit.AddSupplement(new Weapon());
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                    var dog = new Dog(commandWords[2]);
                    this.InsertUnit(dog);
                    break;
                case "Human":
                    var human = new Human(commandWords[2]);
                    this.InsertUnit(human);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            Unit targetUnit;
            Unit sourceUnit;
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                case InteractionType.Infest:
                    targetUnit = this.GetUnit(interaction.TargetUnit);
                    sourceUnit = this.GetUnit(interaction.SourceUnit);

                    if (sourceUnit.UnitClassification
                        == InfestationRequirements.
                           RequiredClassificationToInfest(targetUnit.UnitClassification))
                    {
                        targetUnit.AddSupplement(new InfestationSpores());
                    }
                    break;
                default:
                    break;
            }
        }

        protected new Unit GetUnit(string unitId)
        {
            return this.containedUnits.FirstOrDefault((unit) => unit.Id == unitId);
        }

        protected new Unit GetUnit(UnitInfo unitInfo)
        {
            //return this.GetUnit(unitInfo.Id);
            return this.containedUnits.FirstOrDefault((unit) => unit.Id == unitInfo.Id);
        }

        protected new void InsertUnit(Unit unit)
        {
            this.containedUnits.Add(unit);
        }
    }
}
