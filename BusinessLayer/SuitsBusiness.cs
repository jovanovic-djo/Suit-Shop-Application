using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class SuitsBusiness
    {
        private readonly SuitsRepository suitsRepository;
        public SuitsBusiness()
        {
            this.suitsRepository = new SuitsRepository();
        }

        public List<Suit> GetAllSuits()
        {
            return this.suitsRepository.GetAllSuits();
        }

        public bool InsertSuit(Suit s)
        {
            if (this.suitsRepository.InsertSuit(s) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateSuit(Suit s)
        {
            if (this.suitsRepository.UpdateSuit(s) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteSuit(int s)
        {
            if (this.suitsRepository.DeleteSuit(s) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
