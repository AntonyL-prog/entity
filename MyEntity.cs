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
        Particles.Create("particles/explosion.vpcf");
    }
    //Fonction de l'API pour que quand j'écris Melon dans la console, je fais apparaitre mon melon
    [ConCmd.Admin("Melon")]
    //Création de mon instance dans une méthode qui permet de spawn le melon en l'affiliant à ma classe
    static void Test()
    {
        var entity = new MyEntity();
        entity.Spawn();
    }
    //Si l'entité est utilisé(dans cas la "E" je retourne true et j'affiche mon contenue
    public bool OnUse(Entity user)
    {
        Log.Info("Hello");
        Test();
        return true;
    }
    public bool IsUsable(Entity user)
    {
        return true;
    }
}