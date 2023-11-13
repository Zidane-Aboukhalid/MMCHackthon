using Domain.DB;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.TypeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private DBContext context;
    public UnitOfWork(DBContext context)
    {
        this.context = context;
        Categorie = new CategorieRepository(this.context);
        Evenement = new EvenementRepository(this.context);
        EvenementSponseur = new EvenementSponseurRepository(this.context);
        Fichier= new FichierRepository(this.context);
        Lien= new LienRepository(this.context);
        Participant=new ParticipantRepository(this.context);
        Pay=new PayRepository(this.context);
        PublicCible= new PublicCibleRepository(this.context);
        Session= new SessionRepository(this.context);
        Speaker=new SpeakerRepository(this.context);
        Sponseur=new SponseurRepository(this.context);
        User=new UserRepository(this.context);
        Ville=new VilleRepository(this.context);

    }


    public ICategorieRepository Categorie
    {
        get;
        private set;
    }

    public IEvenementRepository Evenement {
        get;
        private set;
    }

    public IEvenementSponseurRepository EvenementSponseur
    {
        get;
        private set;
    }

    public IFichierRepository Fichier
    {
        get;
        private set;
    }

    public ILienRepository Lien
    {
        get;
        private set;
    }

    public IParticipantRepository Participant
    {
        get;
        private set;
    }

    public IPayRepository Pay
    {
        get;
        private set;
    }

    public IPublicCibleRepository PublicCible
    {
        get;
        private set;
    }

    public ISessionRepository Session
    {
        get;
        private set;
    }

    public ISpeakerRepository Speaker
    {
        get;
        private set;
    }

    public ISponseurRepository Sponseur
    {
        get;
        private set;
    }

    public IUserRepository User
    {
        get;
        private set;
    }

    public IVilleRepository Ville
    {
        get;
        private set;
    }

    public void Dispose()
    {
        context.Dispose();
    }
    public int save()
    {
        return context.SaveChanges();
    }

}
