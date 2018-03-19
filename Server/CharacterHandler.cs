using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.CharacterService;
using SimpleRoleplay.Server.Services.ItemService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleRoleplay.Server
{
	internal class CharacterHandler 
		: Script
	{
		public CharacterHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
            API.onResourceStart += OnResourceStartHandler;
        }

        Timer CharacterTimer;
        public void OnResourceStartHandler()
        {
            Task.Run(() => {
                CharacterTimer = API.startTimer(60000, false, () =>
                {
                    API.getAllPlayers().ForEach(client => {
                        if (client.hasData("player"))
                        {
                            Player player = client.getData("player");
                            if (player.Character != null)
                            {
                                player.Character.Position = client.position;
                                player.Character.Rotation = client.rotation;
                                CharacterService.UpdatePlayerWeapons(player.Character);

                                if (!player.Character.IsDeath)
                                {
                                    player.Character.Hunger -= 2;
                                    player.Character.Thirst -= 3;

                                    if (player.Character.Thirst <= 20)
                                    {
                                        API.sendNotificationToPlayer(client, "~o~Information~n~~w~You have not had a ~b~drink ~w~for a while..");
                                        API.playSoundFrontEnd(client, "Click_Fail", "WEB_NAVIGATION_SOUNDS_PHONE");
                                    }

                                    if (player.Character.Hunger <= 15)
                                    {
                                        API.sendNotificationToPlayer(client, "~o~Information~n~~wYou have not ~b~eaten ~w~for a while..");
                                        API.playSoundFrontEnd(client, "Click_Fail", "WEB_NAVIGATION_SOUNDS_PHONE");
                                    }

                                    if (player.Character.Hunger <= 0 || player.Character.Thirst <= 0)
                                    {
                                        client.health -= 10;
                                    }
                                    CharacterService.UpdateHUD(client);
                                }
                            }
                        }
                    });
                });
            });
        }


        public void OnClientEvent(Client client, string eventName, params object[] arguments) //arguments param can contain multiple params
		{
			Player player = null;

			switch (eventName)
			{
				case "CharacterCreatorConfirm":
					Character character = new Character
					{
						SocialClubName = client.socialClubName,
						FirstName = (string)arguments[1],
						LastName = (string)arguments[2],
						Gender = (Gender)arguments[0],
					};
					CharacterService.CreateCharacter(character);
					CharacterService.OpenCharacterSelection(client);
					client.freeze(false);
					break;
				case "CharacterSelectionFinished":
					CharacterService.OpenSpawnMenu(client);
					break;
				case "CharacterSelectionConfirm":
					if (client.hasData("characterselection"))
					{
						List<Character> playercharacters = (List<Character>)client.getData("characterselection");
						Character selectedchar = playercharacters.FirstOrDefault(c => c.Id == (int)arguments[0]);
						if (selectedchar != null)
						{
							// Character Selected
							client.resetData("characterselection");
							CharacterService.CloseCharacterSelection(client);
							CharacterService.UpdateLastUsage(selectedchar.Id);
							player = client.getData("player");
							player.Character = selectedchar;
							CharacterService.ShowPlayerHUD(client, false);
							player.Account.Player.setSyncedData("cash", player.Character.Cash);
							player.Account.Player.setSyncedData("hunger", player.Character.Hunger);
							player.Account.Player.setSyncedData("thirst", player.Character.Thirst);

							switch (player.Character.Gender)
							{
								case Gender.Male:
									client.setSkin(PedHash.FreemodeMale01);
									break;
								case Gender.Female:
									client.setSkin(PedHash.FreemodeFemale01);
									break;
							}
							CharacterService.ApplyAppearance(client, selectedchar);
							return;
						}
						API.kickPlayer(client, "Character not found.. please reconnect..");
					}
					break;

				case "CharacterSelectionPreview":
					if (client.hasData("characterselection"))
					{
						List<Character> playercharacters = (List<Character>)client.getData("characterselection");
						Character selectedchar = playercharacters.FirstOrDefault(c => c.Id == (int)arguments[0]);
						if (selectedchar != null)
						{
							switch (selectedchar.Gender)
							{
								case Gender.Male:
									client.setSkin(PedHash.FreemodeMale01);
									break;
								case Gender.Female:
									client.setSkin(PedHash.FreemodeFemale01);
									break;
							}
							CharacterService.ApplyAppearance(client, selectedchar);
						}
					}
					break;
				case "Inventory_Request":
					API.triggerClientEvent(client, "Inventory_Data", JsonConvert.SerializeObject(CharacterService.GetInventoryMenuItems(client)));
					break;
				case "KeyboardKey_M_Pressed":
					if (!client.hasData("player")) { return; }
					player = client.getData("player");
					if(player.Character.IsDeath || player.Character.IsCuffed) { return; }
					PlayerMenuService.OpenMenu(client);
					break;

				case "Inventory_Select":
					ItemService.UseItem(client, (int)arguments[0]);
					break;

				case "PlayerMenu_ItemSelected":
					PlayerMenuService.ProcessInteractionMenu(client, (string)arguments[0]);
					break;

				// Inventory Actions

				case "Inventory_SelectItemUse":
					ItemService.UseItem(client, (int)arguments[0]);
					break;
				case "Inventory_SelectItemGive":
					ItemService.GiveItem(client, (int)arguments[0], (int)arguments[1]);
					break;
				case "Inventory_SelectItemTrash":
					ItemService.ThrowAway(client, (int)arguments[0], (int)arguments[1]);
					break;
			}
		}
	}
}