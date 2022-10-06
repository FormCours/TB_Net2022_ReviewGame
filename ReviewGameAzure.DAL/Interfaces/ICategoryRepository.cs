using ReviewGameAzure.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewGameAzure.DAL.Interfaces
{
    public interface ICategoryRepository: IRepository<long, CategoryEntity>
    {
        // Permet de définir une interface pour le Repository avec le typpage

        // Permet d'ajouter des méthode spécifique pour ce Repository
    }
}
