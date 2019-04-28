using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace TeamInfected
{
    public class TeamInfected : BaseScript
    {
        public TeamInfected()
        {
            PlayerConnected += new Action<Entity>(entity =>
            {
                entity.Call("notifyonplayercommand", "teamtest", "+actionslot 3");
                entity.OnNotify("teamtest", (player) =>
                    {
                            player.SetField("sessionteam", "axis");
                    });
                entity.SpawnedPlayer += () => OnPlayerSpawned(entity);
            });
        }
        public void OnPlayerSpawned(Entity player)
        {
            TeamSwitch(player);
        }
        public void TeamSwitch(Entity player)
        {
            AfterDelay(1000, () => player.SetField("sessionteam", "axis"));
        }
    }
}
