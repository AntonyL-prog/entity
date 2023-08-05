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

//Classe de mon entité, dérivé d'un parent animatedentity et IUSE
internal class MyEntity : AnimatedEntity, IUse
{
    //Méthode de mon entité, qui fait apparaitre grace a base qui est une référence de AnimatedEntity ma classe
    public MyEntity()
    {
        base.Spawn();
        UseAnimGraph = true;
    }
    //Méthode qui permet de définire mes attributs de mon entité ainsi que la physique
    public override void Spawn()
    {
        // Always network this entity to all clients
        Transmit = TransmitType.Always;
        Log.Info($"Melon Spawned");
        SetModel("models/sbox_props/watermelon/watermelon.vmdl_c");
        SetupPhysicsFromModel(PhysicsMotionType.Dynamic);
    }
    //Fonction de l'API pour que quand j'écris Melon dans la console, je fais apparaitre mon melon
    [ConCmd.Admin("Melon")]
    //Création de mon instance dans une méthode qui permet de spawn le melon en l'affiliant à ma classe
    static void Test()
    {
        var entity = new MyEntity();
        entity.Spawn();
        //Vector3(0,0,0);
    }
    //Si l'entité est utilisé(dans cas la "E" je retourne true et j'affiche mon contenue
    public bool OnUse(Entity user)
    {
        var position = base.Position;
        MyEntity entité = new MyEntity();
        entité.SetModel("models/sbox_props/watermelon/watermelon.vmdl_c");
        entité.SetupPhysicsFromModel(PhysicsMotionType.Dynamic);
        entité.Position = position;
        return true;
    }
    public bool IsUsable(Entity user)
    {
        return true;
    }
    //public static void Vector3(float x , float y, float z)
   // {
   //     MyEntity.Position = MyEntity.Position + (Vector3.up * 100);
   // }


}
