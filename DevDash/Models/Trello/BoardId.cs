using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrelloNet;

namespace DevDash.Models.Trello
{
    public class BoardId: IBoardId
    {
        public string TrelloBoardId { get; }

        public string GetBoardId()
        {
            return TrelloBoardId;
        }
    }
}
