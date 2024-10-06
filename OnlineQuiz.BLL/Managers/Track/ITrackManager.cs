using OnlineQuiz.BLL.Dtos.Track;
using OnlineQuiz.BLL.Managers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.Track
{
    public interface ITrackManager : IManager<TrackDto, int>
    {
        // No additional methods needed, as CRUD is handled by IManager
    }
}
