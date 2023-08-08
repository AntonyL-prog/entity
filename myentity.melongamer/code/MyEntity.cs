using Sandbox;
using Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Transactions;
using Sandbox.UI;
using Sandbox.Internal;
using Sandbox.UI.Construct;

namespace Sandbox;
//Class of my Entity, subclass of animatedEntity and IUSE
internal class MyEntity : AnimatedEntity, IUse
{
    //Method constructor of my entity that spawn with base that derive from AnimatedEntity
    public  MyEntity()
    {
        base.Spawn();
        UseAnimGraph = true;
    }
    //Method that specify attributs of my entity and his physic
    public override void Spawn()
    {
        // Always network this entity to all clients
        Transmit = TransmitType.Always;
        Log.Info($"Melon Spawned");
        SetModel("models/sbox_props/watermelon/watermelon.vmdl_c");
        SetupPhysicsFromModel(PhysicsMotionType.Dynamic);
    }
    //For Admin if they want to spawn it manually
    [ConCmd.Admin("Melon")]
    //Method that create an instance of my entity and make spawn the entity
    static void Test()
    {
        var entity = new MyEntity();
        entity.Spawn();
        //Vector3(0,0,0);
    }
    //If my entity is used with "E" I make an instance of my entity, and make another entity on the position of the last entity
    public bool OnUse(Entity user)
    {

        var position = base.Position;
        MyEntity entité = new MyEntity();
        entité.SetModel("models/sbox_props/watermelon/watermelon.vmdl_c");
        entité.SetupPhysicsFromModel(PhysicsMotionType.Dynamic);
        var steamid = 76561198049395102;
        Message("Melon", "Spawned", steamid);
        entité.Position = position;
        return true;
    }
    //Don't worry about this
    public bool IsUsable(Entity user)
    {
        return true;
    }
    //public static void Vector3(float x , float y, float z)
    // {
    //     MyEntity.Position = MyEntity.Position + (Vector3.up * 100);
    // }
    
    //Method that say something in the chat
    public static void Message(string name, string message,long PlayerId)
        {
          Chat.AddChatEntry(name, message, PlayerId);
          Chat.Say(message);
        }
}
