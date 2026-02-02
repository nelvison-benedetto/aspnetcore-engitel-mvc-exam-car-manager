using EngitelExam.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngitelExam.Web.Services.Contracts
{
    public interface IFamigliaService
    {
        //Task<int> AddFamigliaWithPersonAsync(CreateFamigliaPersonModel model);
        Task<int> SaveFamigliaAsync(Step1FamigliaVM step1, Step2VeicoliVM step2);
        Task<IEnumerable<FamigliaListItemVM>> GetAllFamiglie();

    }
}
