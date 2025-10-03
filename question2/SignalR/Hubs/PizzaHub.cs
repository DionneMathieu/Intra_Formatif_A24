using Microsoft.AspNetCore.SignalR;
using SignalR.Services;

namespace SignalR.Hubs
{
    public class PizzaHub : Hub
    {
        private readonly PizzaManager _pizzaManager;

        public PizzaHub(PizzaManager pizzaManager) {
            _pizzaManager = pizzaManager;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            //Ajoute l'utilisateur
            _pizzaManager.AddUser();

            //Mise a jour du nombre d'utilisateur
            await Clients.All.SendAsync("UpdateNbUsers ", _pizzaManager.NbConnectedUsers);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnConnectedAsync();
            //Retire l'utilisateur
            _pizzaManager.RemoveUser();

            //Mise a jour du nombre d'utilisateur
            await Clients.All.SendAsync("UpdateNbUsers ", _pizzaManager.NbConnectedUsers);
        }

        public async Task SelectChoice(PizzaChoice choice)
        {
            //Groupe 1 = choix de la pizza selon le nom
            string Choix = _pizzaManager.GetGroupName(choice);
            
            /*
            int money = _pizzaManager.Money[(int)choice];
            int pizzaPrice = _pizzaManager.PIZZA_PRICES[(int)choice];
            int nbPizzas = _pizzaManager.NbPizzas[(int)choice];

            int[] nbPizzaAndMoney = [money, nbPizzas];

            await Groups.AddToGroupAsync(Context.ConnectionId, Choix);

            await Clients.Group(Choix).SendAsync("UpdateNbPizzasAndMoney", nbPizzaAndMoney);
            await Clients.All.SendAsync("UpdatePizzaPrice", pizzaPrice);
            */

            
             int[] nbPizzaAndMoney = [_pizzaManager.Money[(int)choice], _pizzaManager.NbPizzas[(int)choice]];
              
            await Groups.AddToGroupAsync(Context.ConnectionId, _pizzaManager.GetGroupName(choice));
            
            await Clients.Group(_pizzaManager.GetGroupName(choice)).SendAsync("UpdateNbPizzasAndMoney", nbPizzaAndMoney)

             

        }

        public async Task UnselectChoice(PizzaChoice choice)
        {
        }

        public async Task AddMoney(PizzaChoice choice)
        {
        }

        public async Task BuyPizza(PizzaChoice choice)
        {
        }
    }
}
