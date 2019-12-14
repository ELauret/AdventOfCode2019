using System;
using System.Collections.Generic;
using System.Linq;

namespace DayFourteen.Model
{
    public class Reactor
    {
        public List<Reaction> Reactions { get; }
        public Dictionary<string, Quantities> Reactants { get; private set; }

        public Reactor(IEnumerable<string> reactions)
        {
            Reactions = new List<Reaction>();
            if (reactions != null)
            {
                foreach (var reaction in reactions)
                {
                    Reactions.Add(new Reaction(reaction));
                }
            }

            ResetReactants();
        }

        private void ResetReactants()
        {
            Reactants = new Dictionary<string, Quantities>();
            var reactants = Reactions.SelectMany(r => r.Reactants).Select(c => c.Type).Distinct();
            foreach (var reactant in reactants)
            {
                Reactants.Add(reactant, new Quantities());
            }
        }

        public long RequiredToProduce(string baseReactant, string chemicalToProduce, long quantity)
        {
            if (quantity == 0) return 0;

            var reaction = Reactions.Find(r => r.Product.Type == chemicalToProduce);

            if (reaction == null) return 0;

            var ratio = (long)Math.Ceiling((double)quantity / reaction.Product.Quantity);

            if (Reactants.ContainsKey(reaction.Product.Type))
            {
                var product = Reactants[reaction.Product.Type];
                product.Remaining += ratio * reaction.Product.Quantity - quantity;
                Reactants[reaction.Product.Type] = product;
            }

            foreach (var reactant in reaction.Reactants)
            {
                var ingredient = Reactants[reactant.Type];
                long reactantQuantity = ratio * reactant.Quantity;
                if (ingredient.Remaining > 0)
                {
                    if (reactantQuantity < ingredient.Remaining)
                    {
                        ingredient.Remaining -= reactantQuantity;
                        reactantQuantity = 0;
                    }
                    else
                    {
                        reactantQuantity -= ingredient.Remaining;
                        ingredient.Remaining = 0;
                    }
                }
                ingredient.Consumed += reactantQuantity;
                Reactants[reactant.Type] = ingredient;

                _ = RequiredToProduce(baseReactant, reactant.Type, reactantQuantity);
            }

            return Reactants[baseReactant].Consumed;
        }

        public long MaxFuelProducedWith(long oreQuantity)
        {
            long minFuel = 0;
            long maxFuel = oreQuantity;
            long producedFuel = 0;

            while (maxFuel - minFuel > 1)
            {
                producedFuel = (maxFuel + minFuel) / 2;

                ResetReactants();
                var neededOre = RequiredToProduce("ORE", "FUEL", producedFuel);

                if (neededOre < oreQuantity) minFuel = producedFuel;
                else maxFuel = producedFuel;
            }

            return producedFuel;
        }
    }
}
