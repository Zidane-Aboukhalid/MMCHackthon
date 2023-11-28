using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Infrastructure.UnitOfWork;
public interface IUnitOfWork : IDisposable
{
    ICategorieRepository Categorie
    {
        get;
    }
    IEvenementRepository Evenement
    {
        get;
    }
    IEvenementSponseurRepository EvenementSponseur
    {
        get;
    }
    IFichierRepository Fichier
    {
        get;
    }
    ILienRepository Lien
    {
        get;
    }
    IParticipantRepository Participant
    {
        get;
    }
    IPayRepository Pay
    {
        get;
    }
    IPublicCibleRepository PublicCible
    {
        get;
    }
    ISessionRepository Session
    {
        get;
    }
    ISpeakerRepository Speaker
    {
        get;
    }
    ISponseurRepository Sponseur
    {
        get;
    }
    IUserRepository User
    {
        get;
    }
    IVilleRepository Ville
    {
        get;
    }
    IEnumerable<object> Participants { get; }

    int save();
    void Save();
    void Update(Participant existingParticipant);
}