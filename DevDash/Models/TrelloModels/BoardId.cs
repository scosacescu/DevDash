using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloNet;

namespace DevDash.Models.TrelloModels
{
    public class BoardId: IBoardId
    {
        public string TrelloBoardId { get;  set; }

        public string GetBoardId()
        {
            return TrelloBoardId;
        }
    }
}
